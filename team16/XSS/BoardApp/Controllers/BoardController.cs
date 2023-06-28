using BoardApp;
using BoardApp.Models.DTO;
using BoardApp.Models.Exceptions;
using BoardApp.Services.Contracts;
using BoardApp.Services.Implementations;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Controllers
{
    public partial class BoardController : Controller
    {
        private readonly IBoardService _boardService;
        private readonly IUserService _userService;
        public BoardController(IBoardService boardService, IUserService userService)
        {
            _boardService = boardService;
            _userService = userService;
        }

        [HttpGet]
        [Authorize]
        public async Task<OperationResult<List<UserShortDTO>>> UsersNotInBoard([FromRoute] Guid boardId)
        {
            var result = await _userService.GetUsersNotInBoard(boardId);
            return result;
        }

        [HttpGet]
        public async Task<IActionResult> Boards(string? name = default)
        {
            ViewBag.Name = name;
            var result = await _boardService.GetBoards(name);
            return result.Evaluate<IActionResult>(this.ToView, this.ToError);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Board([FromRoute] Guid id)
        {
            var result = await _boardService.GetBoard(id, new Guid(User.Identity!.Name!));
            var usersNotInBoardResult = await UsersNotInBoard(id);

            if (usersNotInBoardResult.IsFailed)
            {
                return this.ToError(result.Exception!);
            }

            ViewBag.UserNotInBoard = usersNotInBoardResult.Value!;

            if (result.IsFailed && result.Exception is AccessDeniedException)
            {
                var accessResult = await _boardService.AccessBoard(id);
                if (accessResult.IsSucceeded) return RedirectToAction("enter", "board", new { id });
            }


            return result.Evaluate<IActionResult>(this.ToView, this.ToError);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Edit([FromRoute] Guid id)
        {
            ViewBag.Id = id;
            var result = await _boardService.GetBoard(id, new Guid(User.Identity!.Name!));
            return result.Evaluate<IActionResult>(() =>
            {
                return View(new EditBoardDTO
                {
                    Name = result.Value!.Name,
                    IsPrivate = result.Value!.IsPrivate
                });
            }, this.ToError);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit([FromRoute] Guid id, [FromForm] EditBoardDTO dto)
        {
            if (!ModelState.IsValid)
            {
                return View(dto);
            }
            ViewBag.Id = id;
            var result = await _boardService.EditBoard(id, dto, new Guid(User.Identity!.Name!));

            return result.Evaluate<IActionResult>(() =>
            {
                return RedirectToAction("board", "board", new { id });
            }, this.ReturnWithError, dto);
        }

        [HttpGet]
        [Authorize]
        public async Task<IActionResult> Delete([FromRoute] Guid id)
        {
            ViewBag.Id = id;
            var result = await _boardService.GetBoard(id, new Guid(User.Identity!.Name!));
            return result.Evaluate<IActionResult>(() =>
            {
                return View(result.Value!);
            }, this.ToError);
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Delete([FromRoute] Guid id, bool overload = true)
        {
            ViewBag.Id = id;
            var result = await _boardService.DeleteBoard(id, new Guid(User.Identity!.Name!));

            return result.Evaluate<IActionResult>(() =>
            {
                return RedirectToAction("boards", "board");
            }, this.ReturnWithError, null);
        }

        [HttpGet]
        [Authorize]
#pragma warning disable CS1998
        public async Task<IActionResult> Create()
#pragma warning restore CS1998
        {
            return View(new CreateBoardDTO());
        }

        [HttpPost]
        [Authorize]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromForm] CreateBoardDTO dto)
        {
            var result = await _boardService.CreateBoard(dto, new Guid(User.Identity!.Name!));
            return result.Evaluate<IActionResult>(() =>
            {
                return RedirectToAction("Board", "Board", new { id = result.Value!.Id });
            }, this.ReturnWithError, dto);
        }
    }
}