using AutoMapper;
using FirstProject.BL.DTOs;
using FirstProject.Core.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Net.WebSockets;

namespace FirstProject.MVC.Controllers
{
    [Authorize(Roles = "Admin")]

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
                return View(appUserDto);
            }
            if (appUserDto.Password != appUserDto.ConfirmPassword)
            {
                ModelState.AddModelError(string.Empty, "password ile Confirm Password eyni deyil");
                return View(appUserDto);
            }
            AppUser user = _mapper.Map<AppUser>(appUserDto);
            await _userManager.CreateAsync(user, appUserDto.Password);
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
                return View(appUserLoginDto);
            }
            AppUser? user = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Bu hesab tapilmadi");
                return View(appUserLoginDto);
            }
            var res = await _signInManager.PasswordSignInAsync(user, appUserLoginDto.Password, true, true);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "Bu hesaba daxil oluna bilinmedi");
                return View(appUserLoginDto);
            }
            return RedirectToAction("Index", "Home");
        }
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();
            return RedirectToAction("Index", "Home");
        }
        /*public async Task CreateRole()
        {
           await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
           await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
           await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
        }*/


        /*public async Task CreateAdmin()
        {
            AppUser appUser  = new AppUser();
            appUser.FirstName = "Admin";
            appUser.LastName = "Admin";
            appUser.UserName = "Admin";
            appUser.Email = "Admin12@admin";
            await _userManager.CreateAsync(appUser, "Admin123!");

            await _userManager.AddToRoleAsync(appUser, "Admin");
        }
        public async Task CreateManager()
        {
            AppUser appUser = new AppUser();
            appUser.FirstName = "Manager";
            appUser.LastName = "Manager";
            appUser.UserName = "Manager";
            appUser.Email = "Manager12@manager";
            await _userManager.CreateAsync(appUser, "Manager123!");
            await _userManager.AddToRoleAsync(appUser, "Manager");
        }*/
    }
}
