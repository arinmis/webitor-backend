using System.Collections.Generic;
using Core.Entities;
using System.Threading.Tasks;

namespace Core.Interfaces.Repositories
{
    public interface IFileRepositoryAsync : IGenericRepositoryAsync<File>
    {

        Task<File> GetFileByPathAsync(string path);
        Task<IReadOnlyList<File>> getFilesByUserIdAsync(string userId);

    }
}
