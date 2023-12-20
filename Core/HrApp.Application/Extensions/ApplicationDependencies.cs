using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HrApp.Application.Extensions
{
   public static class ApplicationDependencies
   {
      public static void AddApplicationDependencies(this IServiceCollection services)
      {
         //todo: expception yenilebilir
         services.AddMediatR(Assembly.GetExecutingAssembly());
         services.AddAutoMapper(Assembly.GetExecutingAssembly());
         services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
      }
   }
}
