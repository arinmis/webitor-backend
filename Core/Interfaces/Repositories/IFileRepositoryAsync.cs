using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFileRepositoryAsync : IGenericRepositoryAsync<File>
    {

        Task<File> GetFileAsync(string projectName, string path);
        Task<IReadOnlyList<File>> GetAllFilesAsync(string projectName);

        Task<File> CreateFileAsync(string projectName, string path, string Content);
    }
}
