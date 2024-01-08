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
        private readonly IAppUserRepository _userRepository;
        private readonly IAdvanceRepository _advanceRepository;
        private readonly ILeaveRepository _leaveRepository;
        private readonly IExpenseRepository _expenseRepository;
        private readonly IExpenseTypeRepository _expenseTypeRepository;
        private readonly IAdvanceTypeRepository _advanceTypeRepository;
        private readonly ILeaveTypeRepository _leaveTypeRepository;
        private readonly ICurrencyRepository _currencyRepository;
        private readonly ICompanyRepository _companyRepository;
        private readonly ICompanyTypeRepository _companyTypeRepository;

        public Uow(HrAppDbContext context,
            IAppUserRepository userRepository,
            IAdvanceRepository advanceRepository,
            ILeaveRepository leaveLeaveory,
            IExpenseRepository expenseRepository,
            IExpenseTypeRepository expenseTypeRepository,
            IAdvanceTypeRepository advanceTypeRepository,
            ILeaveTypeRepository leaveTypeRepository,
            ICurrencyRepository currencyRepository,
            ICompanyRepository companyRepository,
            ICompanyTypeRepository companyTypeRepository
  )
        {
            _context = context;
            _userRepository = userRepository;
            _advanceRepository = advanceRepository;
            _leaveRepository = leaveLeaveory;
            _expenseRepository = expenseRepository;
            _expenseTypeRepository = expenseTypeRepository;
            _advanceTypeRepository = advanceTypeRepository;
            _leaveTypeRepository = leaveTypeRepository;
            _currencyRepository = currencyRepository;
            _companyRepository = companyRepository;
            _companyTypeRepository = companyTypeRepository;
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public IAppUserRepository GetAppUserRepository()
        {
            return _userRepository;
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

        public ICompanyRepository GetCompanyRepository()
        {
            return _companyRepository;
        }

        public ICompanyTypeRepository GetCompanyTypeRepository()
        {
            return _companyTypeRepository;
        }
    }
}
