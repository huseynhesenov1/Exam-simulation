using AutoMapper;
using Listrace.BL.DTOs;
using Listrace.BL.Services.Abstractions;
using Listrace.Core.Entities;
using Listrace.DAL.Contexts;
using Listrace.DAL.Repositories.Abstractions;

namespace Listrace.BL.Services.Implementations
{
	public class PlaceService : IPlaceService
	{
		private readonly IPlaceRepository _placeRepo;
		private readonly AppDbContext _context;
		private readonly IMapper _mapper;

		public PlaceService(IPlaceRepository placeRepo, IMapper mapper, AppDbContext context)
		{
			_placeRepo = placeRepo;
			_mapper = mapper;
			_context = context;
		}

		public async Task<Place> CreateAsync(PlaceDto placeDto)
		{
			

			var folder = Path.Combine("wwwroot", "ImageUpload");
			var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);

            if (!Directory.Exists(pathToSave))
            {
				Directory.CreateDirectory(pathToSave);
            }

			var fileName = placeDto.ImageUrl.FileName;

			var fullPath = Path.Combine(pathToSave, fileName);	
			if (File.Exists(fullPath)) 
			{
				fileName = Path.GetFileNameWithoutExtension(fileName) + Guid.NewGuid() + Path.GetExtension(fileName);
				fullPath = Path.Combine(pathToSave, fileName);
			}
			using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
			{
				await placeDto.ImageUrl.CopyToAsync(fileStream);
			}

			Place place = _mapper.Map<Place>(placeDto);
			place.CreateAt = DateTime.Now;
			place.ImageUrl = fileName;
			var res = await _placeRepo.CreateAsync(place);
			await _context.SaveChangesAsync();
			return res;
		}

		public async Task<ICollection<Place>> GetAllAsync()
		{
			return await _placeRepo.GetAllAsync("Catagory");
		}

        public async Task<Place> GetByIdAsync(int id)
        {
           Place place = await _placeRepo.GetByIdAsync(id);
			return place;
        }

        public async Task<Place> SoftDeleteAsync(int id)
		{
			Place place = await _placeRepo.GetByIdAsync(id);
			Place softPlace = _placeRepo.SoftDelete(place);
			await _context.SaveChangesAsync();	
			return softPlace;
		}

	}
}
