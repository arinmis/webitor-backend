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

        public async Task UpdateFile(string fileName, string content)
        {
            // Update the file here

            // And then send the update to all clients in the group
            await Clients.Group(fileName).SendAsync("updateClient", content);
        }

        public async Task JoinFile(string fileName)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, fileName);
        }

        // Remove these methods if you are not using them
        public async Task LockOtherClients()
        {
            await Clients.Others.SendAsync("lockClient");
        }

        public async Task UpdateOtherClients()
        {
            await Clients.Others.SendAsync("updateClient");
        }
        public async Task UpdateOtherClientsInGroup(string fileName, string content)
        {
            await Clients.OthersInGroup(fileName).SendAsync("updateClient", content);
        }

    }
}
