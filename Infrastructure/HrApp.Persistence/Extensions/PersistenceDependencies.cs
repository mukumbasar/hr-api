using HrApp.Application.Interfaces;
using HrApp.Persistence.Context;
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

            services.AddScoped<IUow, Uow>();
            #endregion
        }
    }
}
