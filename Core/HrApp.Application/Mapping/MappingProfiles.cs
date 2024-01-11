using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using HrApp.Application.CQRS.Advance.Commands;
using HrApp.Application.CQRS.AppUser.Commands;
using HrApp.Application.CQRS.Company.Commands;
using HrApp.Application.CQRS.Expense.Commands;
using HrApp.Application.CQRS.Leave.Commands;
using HrApp.Application.Dtos;
using HrApp.Domain.Entities;

namespace HrApp.Application.Mapping
{
   internal class MappingProfiles : Profile
   {
      public MappingProfiles()
      {
            CreateMap<AppUser, AppUserDetailsDto>();
            CreateMap<AppUser, AppUserHomeDto>();
            CreateMap<AppUser, AppUserUpdateDto>();
            CreateMap<AddAppUserCommand, AppUser>();
            CreateMap<AppUser,AppUserDto>();

            CreateMap<CreateAdvanceCommand, Advance>();
            CreateMap<UpdateAdvanceCommand, Advance>();
            CreateMap<Advance, AdvanceDto>();

            CreateMap<CreateExpenseCommand, Expense>();
            CreateMap<UpdateExpenseCommand, Expense>();
            CreateMap<Expense, ExpenseDto>();

            CreateMap<CreateLeaveCommand, Leave>();
            CreateMap<UpdateLeaveCommand, Leave>();
            CreateMap<Leave, LeaveDto>();

            CreateMap<AdvanceType, AdvanceTypeDto>();
            CreateMap<ExpenseType, ExpenseTypeDto>();
            CreateMap<LeaveType, LeaveTypeDto>();
            CreateMap<Currency, CurrencyDto>();
            
            CreateMap<AddCompanyCommand, Company>();
            CreateMap<UpdateCompanyCommand, Company>();
            CreateMap<Company, CompanyDto>();
            

            CreateMap<CompanyType, CompanyTypeDto>();
        }
   }
}
