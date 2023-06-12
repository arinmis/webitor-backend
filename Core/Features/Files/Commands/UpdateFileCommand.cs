using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands
{
    public class UpdateFileCommand : IRequest<Response<string>>
    {
        public string projectName { get; set; }
        public string path { get; set; }
        public string content { get; set; }
        public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, Response<string>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public UpdateFileCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<string>> Handle(UpdateFileCommand command, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetFileAsync(command.projectName, command.path);

                if (file == null) throw new EntityNotFoundException("file", command.path);

                file.Content = command.content;
                await _fileRepository.UpdateAsync(file);
                return new Response<string>{
                    Data = file.Path,
                    Succeeded = true,
                };
            }
        }
    }
}
