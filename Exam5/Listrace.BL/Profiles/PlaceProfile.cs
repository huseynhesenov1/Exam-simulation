using AutoMapper;
using Listrace.BL.DTOs;
using Listrace.Core.Entities;

namespace Listrace.BL.Profiles
{
	public class PlaceProfile :Profile
	{
        public PlaceProfile()
        {
            CreateMap<Place , PlaceDto>();
            CreateMap<Place , PlaceDto>().ReverseMap();
        }
    }
}
