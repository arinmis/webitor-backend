using AutoMapper;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Files.Commands
{
    public partial class CreateFileCommand : IRequest<Response<string>>
    {
        public string Path { get; set; }
        public string Content { get; set; }
    }

    public class CreateFileCommandHandler : IRequestHandler<CreateFileCommand, Response<string>>
    {
        private readonly IFileRepositoryAsync _fileRepository;
        private readonly IMapper _mapper;
        public CreateFileCommandHandler(IFileRepositoryAsync fileRepository, IMapper mapper)
        {
            _fileRepository = fileRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateFileCommand request, CancellationToken cancellationToken)
        {
            var file = await _fileRepository.CreateFileAsync(request.Path, request.Content);

            if (_fileRepository.GetFileByPathAsync(file.Path).Result != null)
            {
                return new Response<string> { Message = $"file with path: {file.Path} already exists." };
            }

            await _fileRepository.AddAsync(file);
            return new Response<string> { Succeeded = true, Data = file.Path, Message = $"file created with path: {file.Path}" };
        }
    }
}
