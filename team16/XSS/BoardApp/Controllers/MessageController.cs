using BoardApp;
using BoardApp.Models.DTO;
using BoardApp.Services.Contracts;
using FeastHub.Common.Utilities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BoardApp.Controllers
{
    [Authorize]
    [Route("message")]
    public class MessageController : Controller
    {
        private readonly IMessageService _messageService;
        public MessageController(
            IMessageService messageService
        )
        {
            _messageService = messageService;
        }

        [HttpPost]
        [Route("send")]
        public async Task<IActionResult> Send([FromQuery] Guid boardId, [FromBody] CreateMessageDTO dto)
        {
            var userId = new Guid(User.Identity!.Name!);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _messageService.SendMessage(boardId, dto, userId);
            return result.Evaluate<IActionResult>(NoContent, OperationResultUtilities.DefaultEvaluator);
        }

        [HttpPost]
        [Route("delete")]
        public async Task<IActionResult> Delete([FromQuery] Guid messageId)
        {
            var userId = new Guid(User.Identity!.Name!);
            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var result = await _messageService.DeleteMessage(messageId, userId);
            return result.Evaluate<IActionResult>(NoContent, OperationResultUtilities.DefaultEvaluator);
        }
    }
}
