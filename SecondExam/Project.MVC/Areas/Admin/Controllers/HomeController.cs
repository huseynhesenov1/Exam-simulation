using AutoMapper;
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
        private readonly ITechnicianService _techSer;
         

        public HomeController(ITechnicianService techSer )
        {
            _techSer = techSer;
             
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Technician> technicians = await _techSer.GetAllAsync();
            return View(technicians);
        }
        public IActionResult Create()
        { 
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Create(TechnicianDTO technicianDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bos input qoymaq olmaz");
                return View(technicianDTO);
            }
            await _techSer.CreateAsync(technicianDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Update(int id)
        {
           Technician technician = await  _techSer.GetByIdForUpdateAsync(id);
            return View(technician);
        }
        [HttpPost]
        public async Task<IActionResult> Update(int id ,TechnicianDTO technicianDTO)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError(string.Empty, "Bos input qoymaq olmaz");
                return View(technicianDTO);
            }
             await _techSer.UpdateAsync(id, technicianDTO);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SoftDelete(int id)
        {
           await  _techSer.SoftDeleteAsync(id);
            return RedirectToAction("Index");
        }

        
    }
}
