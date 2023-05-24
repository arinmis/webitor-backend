
using Core.DTOs.File;
using Core.Wrappers;
using System.Threading.Tasks;

namespace Core.Interfaces
{
    public interface IFileService
    {
        Task<Response<CreateFileResponse>> CreateFileAsync(CreateFileRequest request, string ipAddress);
    }
}
