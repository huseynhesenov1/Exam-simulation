using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;

namespace Project.MVC.Controllers
{
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
    }
}
