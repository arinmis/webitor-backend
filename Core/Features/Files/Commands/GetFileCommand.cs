using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands
{
    public class GetFileCommand : IRequest<Response<File>>
    {
        // public string userId { get; set; }
        public string path { get; set; }
        public string projectName { get; set; }
        public class GetFileWithPathQueryHandler : IRequestHandler<GetFileCommand, Response<File>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public GetFileWithPathQueryHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<File>> Handle(GetFileCommand query, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetFileAsync(query.projectName, query.path);
                if (file == null) throw new ApiException($"File Not Found.");
                return new Response<File>(file);
            }
        }
    }
}
