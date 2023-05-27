using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands.UpdateFile
{
    public class UpdateFileCommand : IRequest<Response<string>>
    {
        public string oldPath { get; set; }
        public string newPath { get; set; }
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
                var file = await _fileRepository.GetFileByPathAsync(command.oldPath);

                if (file == null) throw new EntityNotFoundException("file", command.newPath);

                file.Path = command.newPath;
                file.Content = command.content;
                await _fileRepository.UpdateAsync(file);
                return new Response<string>(file.Path);
            }
        }
    }
}
