using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands.UpdateFile
{
    public class UpdateFileCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
        public class UpdateFileCommandHandler : IRequestHandler<UpdateFileCommand, Response<int>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public UpdateFileCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<int>> Handle(UpdateFileCommand command, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetByIdAsync(command.Id);

                if (file == null) throw new EntityNotFoundException("file", command.Id);



                file.Path = command.Path;
                file.Content = command.Content;
                await _fileRepository.UpdateAsync(file);
                return new Response<int>(file.Id);
            }
        }
    }
}
