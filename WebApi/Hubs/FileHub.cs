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


        public async Task UpdateFile(string userID, string fileName, string content)
        {
            var groupName = $"{userID}_{fileName}";

            // Update the file here

            // And then send the update to all clients in the group
            await Clients.Group(groupName).SendAsync("updateClient", content);
        }

        public async Task JoinFile(string userID, string fileName)
        {
            var groupName = $"{userID}_{fileName}";
            await Groups.AddToGroupAsync(Context.ConnectionId, groupName);
        }

        public async Task UpdateFileOtherClientsInGroup(string userID, string fileName, string content)
        {
            var groupName = $"{userID}_{fileName}";
            await Clients.OthersInGroup(groupName).SendAsync("updateClient", content);
        }

        // Remove these methods if you are not using them
        public async Task LockOtherClients()
        {
            await Clients.Others.SendAsync("lockClient");
        }

        public async Task JoinUserGroup(string userID)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, userID);
        }

        public async Task CreateUserFile(string userID, Boolean isCreated)
        {
            // Create the file here

            // And then notify the user about the new file
            await Clients.Group(userID).SendAsync("newFileCreated", isCreated);
        }

        public async Task NotifyOtherUsers(string userID, Boolean isCreated)
        {
            // Notify the other users about the new file
            await Clients.OthersInGroup(userID).SendAsync("newFileCreated", isCreated);
        }

    }
}
