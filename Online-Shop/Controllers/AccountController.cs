using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Online_Shop.Models;
using Online_Shop.ModelsIdentity;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Authentication;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Http;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Online_Shop.Controllers
{
    public class AccountController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;

        public AccountController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, 
                                ILogger<AccountController> logger)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public IActionResult Index()
        {
            return View();
        }

        // GET: /<controller>/
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Register(RegisterUser user)
        {
            var userIdentity = new ApplicationUser { UserName = user.Username };
            var result = await _userManager.CreateAsync(userIdentity, user.Password);

            if (result.Succeeded)
            {
                await _signInManager.SignInAsync(userIdentity, isPersistent: false);
            }

            return View("Login");
        }

        [HttpGet]
        public async Task<IActionResult> Login()
        {
            await HttpContext.SignOutAsync(IdentityConstants.ExternalScheme);

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult>  Login(LoginUser user)
        {
            var userIdentity = new ApplicationUser { UserName = user.Username };

            var result = await _signInManager.PasswordSignInAsync(userIdentity.UserName, user.Password, true, false);

            if (result.Succeeded)
            {
                return RedirectToAction("Index", "Home");
            }

            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            HttpContext.Session.Clear();

            return RedirectToAction("Index");
        }
    }
}
