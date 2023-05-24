using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Queries.GetFileById
{
    public class GetFileByIdQuery : IRequest<Response<File>>
    {
        public int Id { get; set; }
        public class GetFileByIdQueryHandler : IRequestHandler<GetFileByIdQuery, Response<File>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public GetFileByIdQueryHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<File>> Handle(GetFileByIdQuery query, CancellationToken cancellationToken)
            {
                var file = await _fileRepository.GetByIdAsync(query.Id);
                if (file == null) throw new ApiException($"File Not Found.");
                return new Response<File>(file);
            }
        }
    }
}
