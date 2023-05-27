using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Queries.GetFileWithPath
{
    public class GetFileWithPath : IRequest<Response<File>>
    {
        // public string userId { get; set; }
        public string path { get; set; }
        public class GetFileWithPathQueryHandler : IRequestHandler<GetFileWithPath, Response<File>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public GetFileWithPathQueryHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<File>> Handle(GetFileWithPath query, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetFileByPathAsync(query.path);
                if (file == null) throw new ApiException($"File Not Found.");
                return new Response<File>(file);
            }
        }
    }
}
