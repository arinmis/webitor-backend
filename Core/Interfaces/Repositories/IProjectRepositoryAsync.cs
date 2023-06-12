using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IProjectRepositoryAsync : IGenericRepositoryAsync<Project>
    {
        Task<Project> CreateProjectAsync(string name);

        Task<IReadOnlyList<Project>> GetAllProjectsAsync();
        Task<Project> GetProjectWithNameAsync(string projectName);

    }
}