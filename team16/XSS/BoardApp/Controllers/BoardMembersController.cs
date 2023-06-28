using BoardApp;
using BoardApp.Models.DTO;
using BoardApp.Models.Exceptions;
using BoardApp.Services.Contracts;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Controllers
{
    public partial class BoardController
    {
        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Enter([FromRoute] Guid id)
        {
            var userId = new Guid(User.Identity!.Name!);
            ViewBag.Id = id;
            var accessResult = await _boardService.AccessBoard(id);
            return accessResult.Evaluate<IActionResult>(() =>
            {
                return View(accessResult.Value!);
            }, this.ToError);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Enter([FromRoute] Guid id, bool overload = true)
        {
            ViewBag.Id = id;
            var result = await _boardService.EnterBoard(id, new Guid(User.Identity!.Name!));

            return result.Evaluate<IActionResult>(() =>
            {
                return RedirectToAction("board", "board", new { id });
            }, this.ReturnWithError, null);
        }

        [HttpPost("/board/{id}/add")]
        [Authorize]
        public async Task<IActionResult> Add([FromRoute] Guid id, [FromQuery] Guid memberId)
        {
            var result = await _boardService.AddMember(id, memberId, new Guid(User.Identity!.Name!));

            return result.Evaluate<IActionResult>(NoContent, this.ReturnWithError, null);
        }

        [HttpPost("/board/{id}/kick")]
        [Authorize]
        public async Task<IActionResult> Kick([FromRoute] Guid id, Guid memberId)
        {
            var result = await _boardService.RemoveMember(id, memberId, new Guid(User.Identity!.Name!));

            return result.Evaluate<IActionResult>(NoContent, this.ToError);
        }
    }
}