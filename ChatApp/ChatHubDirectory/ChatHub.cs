using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.SignalR;

namespace ChatApp.ChatHubDirectory
{
    [Authorize]
    public class ChatHub :Hub
    {
        public async Task Send(string message, string userName)
        {
            await this.Clients.All.SendAsync("Receive", message, userName);
        }
       
    }
}

