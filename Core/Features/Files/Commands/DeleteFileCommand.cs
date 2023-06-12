using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands
{
    public class DeleteFileCommand : IRequest<Response<string>>
    {
        public string path { get; set; }
        public string projectName { get; set; }
        public class DeleteFileCommandHandler : IRequestHandler<DeleteFileCommand, Response<string>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public DeleteFileCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<string>> Handle(DeleteFileCommand command, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetFileAsync(command.projectName, command.path);
                if (file == null) throw new ApiException($"File Not Found.");
                await _fileRepository.DeleteAsync(file);
                return new Response<string> { Data = file.Path, Message = $"{file.Path} in the project {file.ProjectName} deleted" };
            }
        }
    }
}
