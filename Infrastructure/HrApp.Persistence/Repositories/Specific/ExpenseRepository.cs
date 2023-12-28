﻿using HrApp.Application.Interfaces;
using HrApp.Domain.Entities;
using HrApp.Persistence.Context;
using HrApp.Persistence.Repositories.Generic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Persistence.Repositories.Specific
{
    public class ExpenseRepository : GenericRepository<Expense>, IExpenseRepository
    {
        public ExpenseRepository(HrAppDbContext context) : base(context)
        {

        }
    }
}