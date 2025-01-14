using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using Project.DAL.Contexts;
using Project.DAL.Repositories.Abstractions;

namespace Project.BL.Services.Implementations
{
    public class TechnicianService : ITechnicianService
    {
        private readonly ITechnicianRepository _techRepo;
        private readonly AppDbContext _context;
        private readonly IMapper _mapper;

        public TechnicianService(ITechnicianRepository techRepo, IMapper mapper, AppDbContext context)
        {
            _techRepo = techRepo;
            _mapper = mapper;
            _context = context;
        }

        public async Task<Technician> CreateAsync(TechnicianDTO technicianDTO)
        {
            Technician createdTech = _mapper.Map<Technician>(technicianDTO);
            createdTech.CreateAt = DateTime.Now;
            Technician technician = await _techRepo.CreateAsync(createdTech);
            await _context.SaveChangesAsync();
            return technician;
        }


        public async Task<ICollection<Technician>> GetAllAsync()
        {
            return await _techRepo.GetAllAsync();
        }

        public async Task<Technician> GetByIdAsync(int id)
        {
            return await _techRepo.GetByIdAsync(id);
        }
        public async Task<Technician> SoftDeleteAsync(int id)
        {
            Technician technician = await _techRepo.GetByIdAsync(id);
           var res = _techRepo.SoftDelete(technician);
           await _context.SaveChangesAsync();
            return res;
        }
        public async Task<Technician> GetByIdForUpdateAsync(int id)
        {
            return await _techRepo.GetByIdForUpdateAsync(id);
        }

        

        public async Task<Technician> UpdateAsync(int id, TechnicianDTO technicianDTO)
        {
            Technician technician = await _techRepo.GetByIdForUpdateAsync(id);
            Technician updateTechnician = _mapper.Map<Technician>(technicianDTO);
            updateTechnician.CreateAt = technician.CreateAt;
            updateTechnician.Id =id;
            updateTechnician.UpdateAt = DateTime.Now;
            var res =  _techRepo.Update(updateTechnician);
            await _context.SaveChangesAsync();
            return res;
        }
    }
}
