using AutoMapper;
using Listrace.BL.DTOs;
using Listrace.Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace Listrace.MVC.Controllers
{
    public class AuthController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;



        private readonly IMapper _mapper;

        public AuthController(UserManager<AppUser> userManager, IMapper mapper, SignInManager<AppUser> signInManager)
        {
            _userManager = userManager;
            _mapper = mapper;
            _signInManager = signInManager;
        }

        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Register(AppUserDto appUserDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bosh input olmaz");
                return View(appUserDto);
            }
            if (appUserDto.Password != appUserDto.PasswordConfirmed)
            {
                ModelState.AddModelError("", "Passwordlar eyni deyil");
                return View(appUserDto);
            }
            AppUser user = _mapper.Map<AppUser>(appUserDto);
            var res = await _userManager.CreateAsync(user, appUserDto.Password);
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Smth went wrong");
                return View(appUserDto);
            }

            return RedirectToAction("Login", "Account");
        }
        public IActionResult Login() { return View(); }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {

            AppUser appUser = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
            if (appUser == null)
            {
                return View(appUserLoginDto);
            }
         await  _signInManager.PasswordSignInAsync(appUser, appUserLoginDto.Password, true, true);
            return RedirectToAction("Index", "Home");
        }

    }
}
