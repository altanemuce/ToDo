using Business.Abstract;
using Core.Entities.Concrete;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace WebUI.Controllers
{
    [AllowAnonymous]
    public class LoginController : Controller
    {
        IUserService _userService;
        public LoginController(IUserService userService)
        {
            _userService = userService;
        }
        public IActionResult Index()
        {
            return View();
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(User user)
        {
            var result = _userService.Login(user);
            if (result.Success == true)
            {
                var claims = new List<Claim> { new Claim(ClaimTypes.Name, user.UserName) };
                var userIdentity = new ClaimsIdentity(claims, "claim");
                ClaimsPrincipal principal = new ClaimsPrincipal(userIdentity);
                HttpContext.SignInAsync(principal);
                return RedirectToAction("GetAll", "Todo");
            }
            else
            {
                ViewData["Fail"] = "Kullanıcı İsmi veya Şifre Hatalı";
                return View();
            }

        }

        public IActionResult Logout()
        {
            HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Login");
        }
    }
}
