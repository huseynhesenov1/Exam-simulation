using Listrace.BL.DTOs;
using Listrace.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Listrace.BL.Services.Abstractions
{
	public interface IPlaceService
	{
		Task<ICollection<Place>> GetAllAsync();
		Task<Place> CreateAsync(PlaceDto placeDto);
		Task<Place> SoftDeleteAsync(int id);
		Task<Place> GetByIdAsync(int id);
	}
}
