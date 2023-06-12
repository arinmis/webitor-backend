using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands
{
    public class DeleteFileWithPathCommand : IRequest<Response<string>>
    {
        public string path { get; set; }
        public class DeleteFileByIdCommandHandler : IRequestHandler<DeleteFileWithPathCommand, Response<string>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public DeleteFileByIdCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<string>> Handle(DeleteFileWithPathCommand command, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetFileByPathAsync(command.path);
                if (file == null) throw new ApiException($"File Not Found.");
                await _fileRepository.DeleteAsync(file);
                return new Response<string> { Data = file.Path, Message = "File deleted" };
            }
        }
    }
}
