using FirstProject.BL.Services.Abstractions;
using FirstProject.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace FirstProject.MVC.Controllers
{
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
    }
}
