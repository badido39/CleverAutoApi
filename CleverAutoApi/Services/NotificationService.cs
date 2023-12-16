using CleverAutoApi.Models;
using CleverAutoApi.SignalR;
using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;

namespace SignalRWebApi.Services
{
    public class NotificationService : INotificationService
    {
        private readonly IHubContext<NotificationHub> _hubContext;

        public NotificationService(IHubContext<NotificationHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public void SendNotification(Notification notification)
        {
            var json = JsonSerializer.Serialize(notification);
            _ = _hubContext.Clients.All.SendAsync("MessageReceived", json);
        }
    }



    public interface INotificationService
    {
        void  SendNotification(Notification notification);
    }
}
