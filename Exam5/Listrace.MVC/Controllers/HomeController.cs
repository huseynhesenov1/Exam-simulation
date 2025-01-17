using Listrace.BL.Services.Abstractions;
using Listrace.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Listrace.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPlaceService _placeService;

		public HomeController(IPlaceService placeService)
		{
			_placeService = placeService;
		}

		public async Task<IActionResult> Index()
        {
            ICollection<Place> pleace = await _placeService.GetAllAsync();
            return View(pleace);
        }

        
    }
}
