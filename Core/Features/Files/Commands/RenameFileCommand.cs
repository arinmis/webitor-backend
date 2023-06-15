using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands
{
    public class RenameFileCommand : IRequest<Response<string>>
    {
        public int projectId { get; set; }
        public string oldPath { get; set; }
        public string newPath { get; set; }
        public class RenameFileCommandHandler : IRequestHandler<RenameFileCommand, Response<string>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public RenameFileCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<string>> Handle(RenameFileCommand command, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetFileAsync(command.projectId, command.oldPath);

                if (file == null) throw new EntityNotFoundException("file", command.oldPath);

                file.Path = command.newPath;
                await _fileRepository.UpdateAsync(file);
                return new Response<string>
                {
                    Data = file.Path,
                    Succeeded = true,
                };
            }
        }
    }
}
