﻿using CashFlow.Domain.Entities;

namespace CashFlow.Domain.Repositories.Expenses
{
    public interface IExpensesWriteOnlyRepository
    {
        Task Add(Expense expense);
        /// <summary>
        /// This function returns TRUE is the deletion successfull otherwise returns FALSE!
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        Task<bool> Delete(long id);
    }
}
