﻿using CashFlow.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;

namespace CashFlow.Infrastructure.DataAccess
{
    public class CashFlowDbContext : DbContext
    {
        public CashFlowDbContext(DbContextOptions<CashFlowDbContext> options) : base(options)
        { }

        public DbSet<Expense> Expenses { get; set; }
    }
}