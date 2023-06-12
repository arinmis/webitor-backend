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


        public async Task<File> GetFileAsync(string projectName, string path)
        {
            File file = _file
            .Where(f => f.CreatedBy == userId && f.Path == path && f.ProjectName == projectName)
            .FirstOrDefault();
            return await Task.FromResult(file);
        }

        public async Task<IReadOnlyList<File>> GetAllFilesAsync(string projectName)
        {
            var files = _file.Where(f => f.CreatedBy == userId && f.ProjectName == projectName).ToList();
            return await Task.FromResult(new ReadOnlyCollection<File>(files));
        }

        public Task<File> CreateFileAsync(string projectName, string path, string Content)
        {
            File file = new File
            {
                ProjectName = projectName,
                Path = path,
                Content = Content,
                CreatedBy = userId
            };
            return Task.FromResult(file);
        }
    }
}
