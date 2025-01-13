using FirstProject.BL.Services.Abstractions;
using FirstProject.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class HomeController : Controller
    {
        private readonly ICartService _cartService;

        public HomeController(ICartService cartService)
        {
            _cartService = cartService;
        }

        public async Task<IActionResult> Index()
        {
            ICollection<Cart> cartList = await _cartService.GetAllAsync();
            return View(cartList);
        }
        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]  
        public async Task<IActionResult> Create(Cart cart)
        {
            await _cartService.CreateAsync(cart);
            return RedirectToAction("Index", "Home");
        }


    }
}
