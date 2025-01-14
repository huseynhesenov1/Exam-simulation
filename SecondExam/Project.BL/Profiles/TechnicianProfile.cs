using AutoMapper;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.BL.Profiles
{
    public class TechnicianProfile:Profile
    {
        public TechnicianProfile()
        {
            CreateMap<Technician , TechnicianDTO >();
            CreateMap<Technician , TechnicianDTO >().ReverseMap();
        }
    }
}
