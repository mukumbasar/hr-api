using HrApp.Application.Interfaces;
using HrApp.Domain.Entities;
using HrApp.Persistence.Context;
using HrApp.Persistence.Repositories.Specific;
using HrApp.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Persistence.Extensions
{
   public static class PersistenceDependencies
   {
      public static void AddPersistenceDependencies(this IServiceCollection services, string connectionString)
      {
         services.AddDbContext<HrAppDbContext>(x =>
         {
            x.UseSqlServer(connectionString);
         });

            #region Uow and Repositories
            services.AddScoped<IExpenseRepository, ExpenseRepository>();
            services.AddScoped<ILeaveRepository, LeaveRepository>();
            services.AddScoped<IAdvanceRepository, AdvanceRepository>();
            services.AddScoped<IAdvanceTypeRepository, AdvanceTypeRepository>();
            services.AddScoped<IExpenseTypeRepository, ExpenseTypeRepository>();
            services.AddScoped<ILeaveTypeRepository, LeaveTypeRepository>();
            services.AddScoped<ICurrencyRepository, CurrencyRepository>();
            services.AddScoped<IUow, Uow>();
         #endregion

         services.AddIdentity<AppUser, AppRole>(options =>
         {
            options.Password.RequireDigit = false;
            options.Password.RequireLowercase = false;
            options.Password.RequireUppercase = false;
            options.Password.RequireNonAlphanumeric = false;
            options.Password.RequiredLength = 4;
         }).AddEntityFrameworkStores<HrAppDbContext>();
      }
   }
}
