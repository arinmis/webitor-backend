using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFileRepositoryAsync : IGenericRepositoryAsync<File>
    {

        Task<File> GetFileAsync(int projectId, string path);
        Task<IReadOnlyList<File>> GetAllFilesAsync(int projectId);

        Task<File> CreateFileAsync(int projectId, string path, string Content);

        Task<IReadOnlyList<File>> GetFilesInFolderAsync(int projectId, string folder);
    }
}
