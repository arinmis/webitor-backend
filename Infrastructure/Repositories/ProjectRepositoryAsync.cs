using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectRepositoryAsync : GenericRepositoryAsync<Project>, IProjectRepositoryAsync
    {
        private readonly DbSet<Project> _project;
        private readonly string userId;

        public ProjectRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _project = dbContext.Set<Project>();
            userId = dbContext.authenticatedUserId;
        }

        public Task<Project> CreateProjectAsync(string name)
        {
            Project project = new Project
            {
                Name = name,
            };
            return Task.FromResult(project);
        }

        public async Task<IReadOnlyList<Project>> GetAllProjectsAsync()
        {

            var collaboratedProjects = _project
                .Where(p => p.Collaborators.Any(c => c.CollaboratorId == userId))
                .ToList();

            var projects = _project.Where(f => f.CreatedBy == userId).ToList();

            var mergedProjects = collaboratedProjects.Concat(projects).ToList();

            return await Task.FromResult(new ReadOnlyCollection<Project>(mergedProjects));

        }


        public async Task<Project> GetProjectWithIdAsync(int projectId)
        {
            var project = _project.Where(p => p.Id == projectId).FirstOrDefault();
            return await Task.FromResult(project);
        }


    }
}
