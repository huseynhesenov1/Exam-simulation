using AutoMapper;
using Listrace.BL.DTOs;
using Listrace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listrace.BL.Profiles
{
    public class AppUserProfile:Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser,AppUserDto>();
            CreateMap<AppUser,AppUserDto>().ReverseMap();
        }
    }
}
