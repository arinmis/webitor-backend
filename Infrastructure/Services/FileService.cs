using Core.Interfaces;
using Core.DTOs.File;
using Core.Wrappers;
using System.Threading.Tasks;

namespace Infrastructure.Services
{
    public class FileService : IFileService
    {

        public async Task<Response<CreateFileResponse>>
        CreateFileAsync(CreateFileRequest request, string ipAddress)
        {
            await Task.CompletedTask;
            var response = new CreateFileResponse
            {
                Path = "/home"
            };

            return new Response<CreateFileResponse>(response);
        }
    }
}


