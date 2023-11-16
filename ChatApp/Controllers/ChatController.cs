using ChatApp.ChatHubDirectory;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChatController : ControllerBase
    {
        private readonly IHubContext<ChatHub> _hubContext;

        public ChatController(IHubContext<ChatHub> hubContext)
        {
            _hubContext = hubContext;
        }

        [HttpPost("Send")]
        [Authorize]
        public async Task<IActionResult> SendMessage([FromBody] string message)
        {
            if (!string.IsNullOrEmpty(message))
            {
                await _hubContext.Clients.All.SendAsync("Receive", message);
            }
            return Ok();
        }
    }
}
