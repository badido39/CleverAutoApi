using Microsoft.AspNetCore.SignalR;

namespace CleverAutoApi.SignalR
{
    public class NotificationHub:Hub
    {
        public async Task SendMessage(string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", message);
        }
    }
}
