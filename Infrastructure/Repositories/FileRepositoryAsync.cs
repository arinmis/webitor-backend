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


        public async Task<File> GetFileAsync(string projectId, string path)
        {
            File file = _file
            .Where(f => f.CreatedBy == userId && f.Path == path && f.ProjectId == projectId)
            .FirstOrDefault();
            return await Task.FromResult(file);
        }

        public async Task<IReadOnlyList<File>> GetAllFilesAsync(string projectId)
        {
            var files = _file.Where(f => f.CreatedBy == userId && f.ProjectId == projectId).ToList();
            return await Task.FromResult(new ReadOnlyCollection<File>(files));
        }

        public Task<File> CreateFileAsync(string projectId, string path, string Content)
        {
            File file = new File
            {
                ProjectId = projectId,
                Path = path,
                Content = Content,
                CreatedBy = userId
            };
            return Task.FromResult(file);
        }



        public async Task<IReadOnlyList<File>> GetFilesInFolderAsync(string projectName, string folder)
        {
            var files = _file.Where(f => f.CreatedBy == userId && f.ProjectId == projectName && f.Path.StartsWith(folder)).ToList();
            return await Task.FromResult(new ReadOnlyCollection<File>(files));
            // return Task.FromResult(new ReadOnlyCollection<File>(files));
        }
    }
}
