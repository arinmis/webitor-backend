using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Features.Files.Queries.GetAllFiles
{
    public class GetAllFiles : IRequest<Response<IReadOnlyList<File>>>
    {
        public string projectName { get; set; }
        public class GetAllFilesQueryHandler : IRequestHandler<GetAllFiles, Response<IReadOnlyList<File>>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public GetAllFilesQueryHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<IReadOnlyList<File>>> Handle(GetAllFiles request, CancellationToken cancellationToken)
            {
                var files = await _fileRepository.GetAllFilesAsync(request.projectName);
                // if (files == null) throw new ApiException($"File Not Found.");
                return new Response<IReadOnlyList<File>>(files);
            }
        }
    }
}
