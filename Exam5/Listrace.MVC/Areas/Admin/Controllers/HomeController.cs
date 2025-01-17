using Listrace.BL.DTOs;
using Listrace.BL.Services.Abstractions;
using Listrace.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Listrace.MVC.Areas.Admin.Controllers
{
	[Area("Admin")]
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
		public IActionResult Error()
		{
			return View();
		}

		public IActionResult Create()
		{
			return View();
		}
		[HttpPost]
		public async Task<IActionResult> Create(PlaceDto placeDto)
		{
			await _placeService.CreateAsync(placeDto);

			return RedirectToAction("Index");
		}
		public async Task<IActionResult> SoftDelete(int id)
		{
			try
			{
				Place place = await _placeService.SoftDeleteAsync(id);
				return RedirectToAction("Index");

			}
			catch (Exception ex)
			{
				return RedirectToAction("Error");
			}

		}
        public async Task<IActionResult> Details(int id)
        {
            try
            {
                Place place = await _placeService.GetByIdAsync(id);
                return View(place);

            }
            catch (Exception ex)
            {
                return RedirectToAction("Error");
            }
           
        }
    }
}
