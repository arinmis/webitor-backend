using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands.DeleteFileById
{
    public class DeleteFileByIdCommand : IRequest<Response<int>>
    {
        public int Id { get; set; }
        public class DeleteFileByIdCommandHandler : IRequestHandler<DeleteFileByIdCommand, Response<int>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public DeleteFileByIdCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<int>> Handle(DeleteFileByIdCommand command, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetByIdAsync(command.Id);
                if (file == null) throw new ApiException($"File Not Found.");
                await _fileRepository.DeleteAsync(file);
                return new Response<int>(file.Id);
            }
        }
    }
}
