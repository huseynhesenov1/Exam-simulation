using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.Core.Entities;
using Project.DAL.Contexs;

namespace Project.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly IMapper _mapper;
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public AccountController(IMapper mapper, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
            _mapper = mapper;
            _userManager = userManager;
            _signInManager = signInManager;
            _roleManager = roleManager;
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
            if (appUserDto.Password != appUserDto.ConfirmPassword)
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
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Login(AppUserLoginDto appUserLoginDto)
        {
            if (!ModelState.IsValid)
            {
                ModelState.AddModelError("", "Bosh input olmaz");
                return View(appUserLoginDto);
            }
            AppUser appUser = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
            if (appUser == null)
            {
                ModelState.AddModelError("", "hesab tapilmadi");
                return View(appUserLoginDto);
            }
            var res = await _signInManager.PasswordSignInAsync(appUser, appUserLoginDto.Password, true, true);
            if (!res.Succeeded)
            {
                ModelState.AddModelError("", "Smth went wrong");
                return View(appUserLoginDto);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        /* public async Task CreateRole()
         {
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin"});
            await _roleManager.CreateAsync(new IdentityRole { Name = "User"});
            await _roleManager.CreateAsync(new IdentityRole { Name = "Manager"});
         }*/

       /* public async Task CreateAdmin()
        {
            AppUser appUser = new AppUser();
            appUser.FirstName = "Admin";
            appUser.LastName = "Admin";
            appUser.UserName = "Admin";
            appUser.Email = "Admin@123";
            await _userManager.CreateAsync(appUser, "Admin123!");
            await _userManager.AddToRoleAsync(appUser, "Admin");
        }*/
    }
}
