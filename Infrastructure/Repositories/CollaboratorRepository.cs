using Core.Interfaces;
using Core.Entities;
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

        private readonly string userId;

        public CollaboratorRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<Collaborator> AddCollaborator(string projectId, string collaboratorUseranme)
        {

            var user = await _dbContext.Users.FirstOrDefaultAsync(x => x.UserName == collaboratorUseranme);
            Collaborator collaborator = new Collaborator
            {
                ProjectId = projectId,
                CollaboratorId = user.Id
            };
            var c = await this.AddAsync(collaborator);
            return await Task.FromResult(collaborator);
        }

        // public async Task<IReadOnlyList<Collaborator>> GetAllCollaborationsAsync(string userName)
        // {
        // }

    }
}

