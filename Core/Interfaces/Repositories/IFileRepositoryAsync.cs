using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFileRepositoryAsync : IGenericRepositoryAsync<File>
    {

        Task<File> GetFileByPathAsync(string path);
        Task<IReadOnlyList<File>> GetAllFilesAsync();

        Task<File> CreateFileAsync(string path, string Content);

    }
}
