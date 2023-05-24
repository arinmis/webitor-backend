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
    public class FileRepositoryAsync : GenericRepositoryAsync<File>, IFileRepositoryAsync
    {
        private readonly DbSet<File> _file;

        public FileRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _file = dbContext.Set<File>();
        }

        public async Task<IReadOnlyList<File>> getFilesByUserIdAsync(string userId)
        {
            var files = _file.Where(f => f.UserId == userId).ToList();
            return await Task.FromResult(new ReadOnlyCollection<File>(files));
        }
    }
}
