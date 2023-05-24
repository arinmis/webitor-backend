using Core.Entities;
using Core.Interfaces.Repositories;
using Infrastructure.Contexts;
using Infrastructure.Repository;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class FileRepositoryAsync : GenericRepositoryAsync<File>, IFileRepositoryAsync
    {
        private readonly DbSet<File> _products;

        public FileRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _products = dbContext.Set<File>();
        }
        


    }
}
