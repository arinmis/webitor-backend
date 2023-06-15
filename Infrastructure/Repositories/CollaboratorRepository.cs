using Core.Interfaces;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using Core.Entities;
using System.Linq;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class CollaboratorRepositoryAsync : GenericRepositoryAsync<Collaborator>
    , ICollaboratorRepositoryAsync
    {
        private readonly ApplicationDbContext _dbContext;
        private readonly DbSet<Collaborator> _collaborator;

        public CollaboratorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
            _collaborator = dbContext.Set<Collaborator>();
        }

        public async Task<Collaborator> AddCollaborator(int projectId, string collaboratorUseranme)
        {

            var user = await _dbContext.Users.Where(x => x.UserName == collaboratorUseranme).FirstOrDefaultAsync();
            Collaborator collaborator = new Collaborator
            {
                ProjectId = projectId,
                CollaboratorId = user.Id
            };
            await this.AddAsync(collaborator);
            return await Task.FromResult(collaborator);
        }

        /* list all collaborators of a project */
        public async Task<IReadOnlyList<Collaborator>> GetAllCollaborationsAsync(int projectId)
        {
            var collaborators = _collaborator.Where(c => c.ProjectId == projectId).ToList();
            return await Task.FromResult(new ReadOnlyCollection<Collaborator>(collaborators));
        }
    }

}

