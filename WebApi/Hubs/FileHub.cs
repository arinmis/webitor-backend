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
            Console.WriteLine($"{user} says: ${message}");
            await Clients.All.SendAsync("receiveMessage", user, message);
        }

        /* calls to this method will be sent to all clients except the caller */
        public async Task LockOtherClients()
        {
            await Clients.Others.SendAsync("lockClient");
        }

        /* call this method to update all clients except the caller */
        public async Task UpdateOtherClients()
        {
            await Clients.Others.SendAsync("updateClient");
        }
    }
}