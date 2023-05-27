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
        private readonly string userId;

        public FileRepositoryAsync(ApplicationDbContext dbContext) : base(dbContext)
        {
            _file = dbContext.Set<File>();
            userId = dbContext.authenticatedUserId;
        }


        public async Task<File> GetFileByPathAsync(string path)
        {
            File file = _file.Where(f => f.CreatedBy == userId && f.Path == path).FirstOrDefault();
            return await Task.FromResult(file);
        }

        public async Task<IReadOnlyList<File>> GetAllFilesAsync()
        {
            var files = _file.Where(f => f.CreatedBy == userId).ToList();
            return await Task.FromResult(new ReadOnlyCollection<File>(files));
        }

        public Task<File> CreateFileAsync(string path, string Content)
        {
            File file = new File
            {
                Path = path,
                Content = Content,
                CreatedBy = userId
            };
            return Task.FromResult(file);
        }
    }
}
