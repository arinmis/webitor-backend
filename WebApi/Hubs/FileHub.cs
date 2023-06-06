using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace WebApi.Hubs
{
    public class FileHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine($"{user} says: ${message}");
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}