using AutoMapper;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;
using Project.DAL.Contexs;
using Project.DAL.Repositories.Abstractions;
using System.Linq.Expressions;

namespace Project.BL.Services.Implementations
{
    public class NewsService : INewsService
    {
        private readonly INewsRepository _newsRepo;
        private readonly IMapper _mapper;
        private readonly AppDbContext _context;
        public NewsService(INewsRepository newsRepo, IMapper mapper, AppDbContext context)
        {
            _newsRepo = newsRepo;
            _mapper = mapper;
            _context = context;
        }
        public async Task<News> UpdateAsync(NewsUpdateDto newsUpdateDto)
        {
            var folder = Path.Combine("wwwroot", "ImageUpload");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }
            int id = newsUpdateDto.Id;
            News news = await GetByIdAsync(id);
            News updateNews = _mapper.Map<News>(newsUpdateDto);


            var fileName = newsUpdateDto.ImageUrl.FileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                fileName = Path.GetFileNameWithoutExtension(fileName) + Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                fullPath = Path.Combine(pathToSave, fileName);
            }
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await newsUpdateDto.ImageUrl.CopyToAsync(fileStream);
            }
            updateNews.ImageUrl = fileName;
            updateNews.UpdateAt = DateTime.Now;
            updateNews.CreateAt = news.CreateAt;

            var res = _newsRepo.Update(updateNews);
            await _context.SaveChangesAsync();
            return res;
        }
        public async Task<News> GetByIdForUpdateAsync(int id)
        {
            return await _newsRepo.GetByIdForUpdateAsync(id);
        }
        public async Task<News> CreateAsync(NewsDto newsDto)
        {
            var folder = Path.Combine("wwwroot", "ImageUpload");
            var pathToSave = Path.Combine(Directory.GetCurrentDirectory(), folder);
            if (!Directory.Exists(pathToSave))
            {
                Directory.CreateDirectory(pathToSave);
            }

            var fileName = newsDto.ImageUrl.FileName;
            var fullPath = Path.Combine(pathToSave, fileName);
            if (System.IO.File.Exists(fullPath))
            {
                fileName = Path.GetFileNameWithoutExtension(fileName) + Guid.NewGuid().ToString() + Path.GetExtension(fileName);
                fullPath = Path.Combine(pathToSave, fileName);
            }
            using (FileStream fileStream = new FileStream(fullPath, FileMode.Create))
            {
                await newsDto.ImageUrl.CopyToAsync(fileStream);
            }

            News news = _mapper.Map<News>(newsDto);
            news.CreateAt = DateTime.Now;
            news.ImageUrl = fileName;
            News createNews = await _newsRepo.CreateAsync(news);
            await _context.SaveChangesAsync();
            return createNews;
        }

        public async Task<ICollection<News>> GetAllAsync()
        {
            return await _newsRepo.GetAllAsync();
        }

        public async Task<News> GetByIdAsync(int id)
        {
            return await _newsRepo.GetByIdAsync(id);
        }



        public async Task<News> SoftDeleteAsync(int id)
        {
            News news = await _newsRepo.GetByIdAsync(id);
            var res = _newsRepo.SoftDelete(news);
            await _context.SaveChangesAsync();
            return res;
        }

        
    }
}
