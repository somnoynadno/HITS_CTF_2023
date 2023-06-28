using BoardApp.Models.DTO;
using BoardApp.Services.Contracts;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;

namespace BoardApp.Controllers
{
    public class AccountController : Controller
    {
        private readonly IAuthService _authService;
        public AccountController(
            IAuthService authService
        )
        {
            _authService = authService;
        }

        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login([FromForm] LoginDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var result = await _authService.Login(dto);
            if (result.IsFailed)
            {
                ModelState.AddModelError("LoginErrors", result.Exception!.Message);
                return View(dto);
            }
            else
            {
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(result.Value!)
                );
                return RedirectToAction("boards", "board");
            }
        }

        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register([FromForm] CreateUserDTO dto)
        {
            if (!ModelState.IsValid)
                return View(dto);
            var result = await _authService.Register(dto);
            if (result.IsFailed)
            {
                ModelState.AddModelError("LoginErrors", result.Exception!.Message);
                return View(dto);
            }
            else
            {
                await HttpContext.SignInAsync(
                    CookieAuthenticationDefaults.AuthenticationScheme,
                    new ClaimsPrincipal(result.Value!)
                );
                return RedirectToAction("boards", "board");
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("boards", "board");
        }
    }
}
