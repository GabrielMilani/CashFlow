﻿using AutoMapper;
using CashFlow.Communication.Requests;
using CashFlow.Domain.Repositories;
using CashFlow.Domain.Repositories.Expenses;
using CashFlow.Exception;
using CashFlow.Exception.ExceptionsBase;

namespace CashFlow.Application.UseCases.Expenses.Update
{
    public class UpdateExpenseUseCase : IUpdateExpenseUseCase
    {
        private readonly IExpensesUpdateOnlyRepository _expenseRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateExpenseUseCase(IExpensesUpdateOnlyRepository expenseRepository, IUnitOfWork unitOfWork, IMapper mapper)
        {
            _expenseRepository = expenseRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }
        public async Task Execute(long id, RequestExpenseJson request)
        {
            Validate(request);
            var expense = await _expenseRepository.GetById(id);
            if (expense is null)
                throw new NotFountException(ResourceErrorMessages.EXPENSE_NOT_FOUND);
            _mapper.Map(request, expense);
            _expenseRepository.Update(expense);
            await _unitOfWork.Commit();
        }

        private void Validate(RequestExpenseJson request)
        {
            var validator = new ExpenseValidator();
            var result = validator.Validate(request);
            if (result.IsValid == false)
            {
                var errorMessages = result.Errors.Select(f => f.ErrorMessage).ToList();
                throw new ErrorOnValidationException(errorMessages);
            }
        }

    }
}
