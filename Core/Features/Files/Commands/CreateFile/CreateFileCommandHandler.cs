using System.Threading;
using System.Threading.Tasks;
using Core.Interfaces.Repositories;
namespace Core.Features.Files.Commands.CreateFile
{
    public class CreateFileCommandHandler : ICreateFileCommandHandler
    {
        private readonly IFileRepositoryAsync _fileRepository;

        public CreateFileCommandHandler(IFileRepositoryAsync fileRepositoryAsync)
        {
            _fileRepository = fileRepositoryAsync;
        }

        public async Task<string> Handle(CreateFileCommand request)
        {
            var file = await _fileRepository.AddAsync(new Entities.File
            {
                Path = request.Path,
                Content = request.Content,
                UserId = request.UserId
            });
            return file.Path;
        }
    }
}