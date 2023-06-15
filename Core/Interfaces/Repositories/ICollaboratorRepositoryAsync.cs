using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface ICollaboratorRepositoryAsync : IGenericRepositoryAsync<Collaborator>
    {
        Task<Collaborator> AddCollaborator(int projectId, string collaboratorUseranme);
        Task<IReadOnlyList<Collaborator>> GetAllCollaborationsAsync(int projectId);

    }
}