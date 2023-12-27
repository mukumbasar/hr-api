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
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly IAdvanceTypeRepository _advanceTypeRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ICurrencyRepository _currencyRepository;

        public Uow(HrAppDbContext context,
            IAdvanceRepository advanceRepository,
            ILeaveRepository leaveLeaveory,
            IExpenseRepository expenseRepository,
            IExpenseTypeRepository expenseTypeRepository,
            IAdvanceTypeRepository advanceTypeRepository,
            ILeaveTypeRepository leaveTypeRepository,
            ICurrencyRepository currencyRepository
  )
        {
            _context = context;
            _advanceRepository = advanceRepository;
            _leaveRepository = leaveLeaveory;
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
            _advanceTypeRepository = advanceTypeRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _currencyRepository = currencyRepository;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IAdvanceRepository GetAdvanceRepository()
        {
            return _advanceRepository;
        }

        public IAdvanceTypeRepository GetAdvanceTypeRepository()
        {
            return _advanceTypeRepository;
        }

        public ICurrencyRepository GetCurrencyRepository()
        {
            return _currencyRepository;
        }

        public IExpenseRepository GetExpenseRepository()
        {
            return _expenseRepository;
        }

        public IExpenseTypeRepository GetExpenseTypeRepository()
        {
            return _expenseTypeRepository;
        }

        public ILeaveRepository GetLeaveRepository()
        {
            return _leaveRepository;
        }

        public ILeaveTypeRepository GetLeaveTypeRepository()
        {
            return _leaveTypeRepository;
        }
    }
}
