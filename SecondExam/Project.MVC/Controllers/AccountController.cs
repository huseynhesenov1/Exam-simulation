using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Project.BL.DTOs;
using Project.Core.Entities;

namespace Project.MVC.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly RoleManager<IdentityRole> _roleManager;

        public AccountController(UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, RoleManager<IdentityRole> roleManager)
        {
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
                ModelState.AddModelError(string.Empty, "password ile confomr passsword eyni olsun");
                return View(appUserDto);
            }
            AppUser appUser = new AppUser();
            appUser.FisrtName = appUserDto.FirstName;
            appUser.LastName = appUserDto.LastName;
            appUser.Email = appUserDto.Email;
            appUser.UserName = appUserDto.UserName;

            await _userManager.CreateAsync(appUser, appUserDto.Password);
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
            AppUser user = await _userManager.FindByNameAsync(appUserLoginDto.UserName);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "hesab tailmadi");
                return View(appUserLoginDto);
            }
            var res = await _signInManager.PasswordSignInAsync(user, appUserLoginDto.Password, true, true);
            if (!res.Succeeded)
            {
                ModelState.AddModelError(string.Empty, "hesab tailmadi");
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
            await _roleManager.CreateAsync(new IdentityRole { Name = "Admin" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "User" });
            await _roleManager.CreateAsync(new IdentityRole { Name = "Manager" });
         }*/
        /*public async Task CreateAdmin()
        {
            AppUser appUser = new AppUser();
            appUser.FisrtName = "Admin";
            appUser.LastName = "Admin";
            appUser.UserName = "Admin";
            appUser.Email = "Admin@com";
            await _userManager.CreateAsync(appUser, "Admin123!");
          await  _userManager.AddToRoleAsync(appUser, "Admin");
        }*/
    }
}
