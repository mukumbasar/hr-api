using HrApp.Application.Interfaces;
using HrApp.Persistence.Context;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Persistence.UnitOfWork
{
    public class Uow : IUow
    {
        private readonly HrAppDbContext _context;
        private readonly IAdvanceRepository _advanceRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IExpenseRepository _expenseRepository;

        public Uow(HrAppDbContext context,
            IAdvanceRepository advanceRepository,
            ILeaveRepository leaveLeaveory,
            IExpenseRepository expenseRepository
  )
        {
            _context = context;
            _advanceRepository = advanceRepository;
            _leaveRepository = leaveLeaveory;
            _expenseRepository = expenseRepository;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IAdvanceRepository GetAdvanceRepository()
        {
            return _advanceRepository;
        }

        public IExpenseRepository GetExpenseRepository()
        {
            return _expenseRepository;
        }

        public ILeaveRepository GetLeaveRepository()
        {
            return _leaveRepository;
        }
    }
}
