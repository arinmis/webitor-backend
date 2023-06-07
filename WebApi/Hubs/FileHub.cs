using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace WebApi.Hubs
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class FileHub : Hub
    {
        public async Task SendMessage(string user, string message)
        {
            Console.WriteLine($"{user} says: {message}");
            await Clients.All.SendAsync("receiveMessage", user, message);
        }

        public async Task addClientToGroup(string userId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userId);
        }
        public async Task removeClientToGroup(string userId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, userId);
        }

        // Remove these methods if you are not using them
        public async Task LockOtherClients(string userId)
        {
            await Clients.OthersInGroup(userId).SendAsync("lockClient");
        }

        public async Task UpdateOtherClients(string userId)
        {
            await Clients.OthersInGroup(userId).SendAsync("updateClient");
        }
    }
}
