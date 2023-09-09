using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using RealTimeDataUpdate.Business.Abstract;
using RealTimeDataUpdate.Entity.Concrete;
using RealTimeDataUpdate.WebUI.Models;
using System;
using System.Security.Claims;
using static RealTimeDataUpdate.Business.Concrete.UserService;

namespace RealTimeDataUpdate.WebUI.Controllers
{
    public class AuthController : Controller
    {
        private readonly IUserService _userService;

        public AuthController(IUserService userService)
        {
            _userService = userService;
        }

        public async Task<IActionResult> LogOut()
        {
            var userEmail = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;
            var user = _userService.FindUserByMail(userEmail!);
            _userService.LogOut(user.Id);
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel loginViewModel)
        {
            var loginResult = _userService.Login(loginViewModel.Mail, loginViewModel.Password);

            if (loginResult == LoginResult.Success)
            {
                var claims = new List<Claim>()
                {
                    new Claim(ClaimTypes.NameIdentifier,loginViewModel.Mail!)

                };

                var identity = new ClaimsIdentity(claims,
                    CookieAuthenticationDefaults.AuthenticationScheme
                    );
                AuthenticationProperties properties = new AuthenticationProperties()
                {
                    AllowRefresh = true,

                };

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(identity), properties);
                // Başarılı giriş, 
                return RedirectToAction("Index", "User");
            }
            else
            {
                // Giriş başarısız
                TempData["ErrorMessage"] = "Kullanıcı adı veya şifre hatalı.";
                return View(); // Giriş Sayfası
            }
        }


        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Register(User user)
        {
            try
            {
                _userService.Register(user);
                TempData["SuccessMessage"] = "Kullanıcı kaydı başarıyla tamamlandı.";
            }
            catch (Exception ex)
            {
                TempData["ErrorMessage"] = "Kullanıcı kaydı sırasında bir hata oluştu: " + ex.Message;
            }

            return RedirectToAction("Login", "Auth");
        }


    }
}
