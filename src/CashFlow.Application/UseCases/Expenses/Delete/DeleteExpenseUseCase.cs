using AutoMapper;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Delete
{
    internal class DeleteExpenseUseCase : IDeleteExpenseUseCase
    {
        private readonly IExpensesWriteOnlyRepository _expensesRepository;
        private readonly IUnitOfWork _unitOfWork;

        public DeleteExpenseUseCase(IExpensesWriteOnlyRepository expensesRepository, IUnitOfWork unitOfWork)
        {
            _expensesRepository = expensesRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Execute(long id)
        {
            var result = await _expensesRepository.Delete(id);

            if (result == false)
            {
                throw new NotFountException("Expense not Found");
            }

            await _unitOfWork.Commit();
        }
    }
}
