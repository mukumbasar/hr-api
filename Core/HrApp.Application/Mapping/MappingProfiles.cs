using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
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
      }
   }
}
