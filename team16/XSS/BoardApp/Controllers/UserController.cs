using BoardApp;
using BoardApp.Models.DTO;
using BoardApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;
        public UserController(
            IUserService userService
        )
        {
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Profile()
        {
            var result = await _userService.GetUser(new Guid(User.Identity!.Name!));
            return result.Evaluate<IActionResult>(() =>
            {
                return View(result.Value!);
            }, this.ToError);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit()
        {
            var result = await _userService.GetUser(new Guid(User.Identity!.Name!));
            return result.Evaluate<IActionResult>(() =>
            {
                return View(new EditUserDTO
                {
                    Username = result.Value!.Username
                });
            }, this.ToError);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromForm] EditUserDTO dto)
        {
            var userId = new Guid(User.Identity!.Name!);
            if (!ModelState.IsValid)
                return View(dto);
            var result = await _userService.EditUser(userId, dto);
            return result.Evaluate<IActionResult>(() =>
            {
                return RedirectToAction("profile");
            }, this.ReturnWithError, dto);
        }
    }
}
