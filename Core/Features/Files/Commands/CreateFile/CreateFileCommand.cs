using AutoMapper;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands.CreateFile
{
    public partial class CreateFileCommand : IRequest<Response<int>>
    {
        public string UserId { get; set; }
        public string Path { get; set; }
        public string Content { get; set; }
    }

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Response<int>>
    {
        private readonly IFileRepositoryAsync _fileRepository;
        private readonly IMapper _mapper;
        public CreateFileCommandHandler(IFileRepositoryAsync fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = _mapper.Map<File>(request);
            await _fileRepository.AddAsync(file);
            return new Response<int>(file.Id);
        }
    }
}