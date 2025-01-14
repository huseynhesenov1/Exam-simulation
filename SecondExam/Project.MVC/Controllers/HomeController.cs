using Microsoft.AspNetCore.Mvc;
using Project.BL.Services.Abstractions;
using Project.Core.Entities;

namespace Project.MVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ITechnicianService _techSer;

        public HomeController(ITechnicianService techSer)
        {
            _techSer = techSer;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Technician> technicians =  await  _techSer.GetAllAsync();
            return View(technicians);
        }
    }
}