using Microsoft.AspNetCore.SignalR;
using System.Threading.Tasks;
using System;

namespace WebApi.Hubs
{
    // [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    public class ProjectHub : Hub
    {

        /* Join and leave project groups */
        public async Task JoinProject(int projectId)
        {
            await Groups.AddToGroupAsync(Context.ConnectionId, projectId.ToString());
        }

        public async Task LeaveProject(int projectId)
        {
            await Groups.RemoveFromGroupAsync(Context.ConnectionId, projectId.ToString());
        }

        /* File CRUD operations */
        public async Task PushFileUpdate(int projectId, string filename, string content)
        {
            Console.WriteLine($"Pushing file update{filename} to project {projectId}");
            await Clients.OthersInGroup(projectId.ToString()).SendAsync("updateFile", filename, content);
        }

        public async Task PushFileCreation(int projectId, string filename)
        {
            await Clients.OthersInGroup(projectId.ToString()).SendAsync("createFile", filename);
        }

    }
}
