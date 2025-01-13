using AutoMapper;
using FirstProject.BL.DTOs;
using FirstProject.Core.Entities;

namespace FirstProject.BL.Profiles
{
    public class AppUserProfile :Profile
    {
        public AppUserProfile()
        {
            CreateMap<AppUser , AppUserDto>();
            CreateMap<AppUser , AppUserDto>().ReverseMap();
        }
    }
}
