﻿using CashFlow.Application.UseCases.Expenses.Reports.Pdf.Fonts;
using CashFlow.Domain.Entities;
using CashFlow.Domain.Reports;
using CashFlow.Domain.Repositories.Expenses;
using DocumentFormat.OpenXml.Bibliography;
using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Fonts;
using System.Reflection;

namespace CashFlow.Application.UseCases.Expenses.Reports.Pdf
{
    public class GenerateExpensesReportPdfUseCase : IGenerateExpensesReportPdfUseCase
    {
        private const string CURRENCY_SYMBOL = "$";
        private readonly IExpensesReadOnlyRepository _expenseRepository;

        public GenerateExpensesReportPdfUseCase(IExpensesReadOnlyRepository expenseRepository)
        {
            _expenseRepository = expenseRepository;

            GlobalFontSettings.FontResolver = new ExpensesReportFontResolver();
        }
        public async Task<byte[]> Execute(DateOnly month)
        {
            var expenses = await _expenseRepository.FilterByMonth(month);
            if (expenses.Count == 0)
                return [];

            var document = CreateDocument(month);
            var page = CreatePage(document);
            CreateHeaderWithProfilePhotoAndName(page);
            var totalExpenses = expenses.Sum(expenses => expenses.Amount);
            CreateTotalSpentSection(page, month, totalExpenses);

            return RenderDocument(document);
        }

        private Document CreateDocument(DateOnly month)
        { 
            var document = new Document();
            document.Info.Title = $"{ResourceReportGenerationMessages.EXPENSES_FOR} {month:Y}";
            document.Info.Author = "Gabriel Elias Milani";

            var style = document.Styles["Normal"];
            style!.Font.Name = FontHelper.RALEWAY_REGULAR;

            return document;
        }

        private Section CreatePage(Document document)
        {
            var section = document.AddSection();
            section.PageSetup = document.DefaultPageSetup.Clone();
            section.PageSetup.PageFormat = PageFormat.A4;
            section.PageSetup.LeftMargin = 40;
            section.PageSetup.RightMargin = 40;
            section.PageSetup.TopMargin = 80;
            section.PageSetup.BottomMargin = 80;

            return section;
        }

        private void CreateHeaderWithProfilePhotoAndName(Section page)
        {
            var table = page.AddTable();
            table.AddColumn();
            table.AddColumn("300");
            var row = table.AddRow();
            var assembly = Assembly.GetExecutingAssembly();
            var directoryName = Path.GetDirectoryName(assembly.Location);
            row.Cells[0].AddImage(Path.Combine(directoryName!, "Logo", "Logo.png"));
            row.Cells[1].AddParagraph("Hey, Gabriel Milani");
            row.Cells[1].Format.Font = new Font { Name = FontHelper.WORKSANS_BLACK, Size = 16 };
            row.Cells[1].VerticalAlignment = MigraDoc.DocumentObjectModel.Tables.VerticalAlignment.Center;
        }

        private void CreateTotalSpentSection(Section page, DateOnly month, decimal totalExpenses)
        {
            var paragraph = page.AddParagraph();
            paragraph.Format.SpaceBefore = "40";
            paragraph.Format.SpaceAfter = "40";
            var title = string.Format(ResourceReportGenerationMessages.TOTAL_SPENT_IN, month.ToString("Y"));
            paragraph.AddFormattedText(title, new Font { Name = FontHelper.RALEWAY_REGULAR, Size = 15 });
            paragraph.AddLineBreak();
            paragraph.AddFormattedText($"{totalExpenses} {CURRENCY_SYMBOL}", new Font { Name = FontHelper.WORKSANS_BLACK, Size = 50 });
        }

        private byte[] RenderDocument(Document document)
        {
            var renderer = new PdfDocumentRenderer
            {
                Document = document,
            };
            renderer.RenderDocument();
            using var file = new MemoryStream();
            renderer.PdfDocument.Save(file);

            return file.ToArray();
        }
    }
}
