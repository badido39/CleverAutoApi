using CleverAutoApi.Models;
using Microsoft.AspNetCore.SignalR;
using System.Diagnostics;
using System.Text.Json;

namespace CleverAutoApi.SignalR
{
    public class NotificationHub:Hub
    {
        public async Task SendMessage(Notification notification)
        {
            var json = JsonSerializer.Serialize(notification);
            Debug.WriteLine(json);
            await Clients.All.SendAsync("MessageReceived", json);
        }
    }
}
