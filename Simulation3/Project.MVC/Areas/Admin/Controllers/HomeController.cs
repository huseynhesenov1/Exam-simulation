using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;

namespace Project.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    
    public class HomeController : Controller
    {
        private readonly INewsService _newsService;

        public HomeController(INewsService newsService)
        {
            _newsService = newsService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<News> news = await _newsService.GetAllAsync();
            return View(news);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(NewsDto newsDto)
        {
           await _newsService.CreateAsync(newsDto);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
           await _newsService.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }
        public IActionResult Update()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Update( NewsUpdateDto  newsUpdateDto )
        {
            var id  = newsUpdateDto.Id;
            NewsDto newsDto = new NewsDto();
            newsDto.ImageUrl = newsUpdateDto.ImageUrl;
            newsDto.CatagoryId = newsUpdateDto.CatagoryId;
            newsDto.ImageUrl = newsUpdateDto.ImageUrl;
            await _newsService.UpdateAsync(newsUpdateDto);
            return RedirectToAction("Index");
        }
    }
}
