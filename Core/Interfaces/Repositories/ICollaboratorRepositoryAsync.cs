using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICollaboratorRepositoryAsync : IGenericRepositoryAsync<Collaborator>
    {
        Task<Collaborator> AddCollaborator(string projectId, string collaboratorUseranme);
        // Task<IReadOnlyList<Collaborator>> GetAllCollaborationsAsync(string userName);
    }
}