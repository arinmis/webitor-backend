using AutoMapper;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Projects.Commands
{
    public partial class CreateProjectCommand : IRequest<Response<int>>
    {
        public string name { get; set; }
    }

    public class CreateProjectCommandHandler : IRequestHandler<CreateProjectCommand, Response<int>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        private readonly IMapper _mapper;
        public CreateProjectCommandHandler(IProjectRepositoryAsync projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(CreateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.CreateProjectAsync(request.name);
            await _projectRepository.AddAsync(project);
            return new Response<int>
            {
                Succeeded = true,
                Data = project.Id,
                Message = $"project created with name: {project.Name}"
            };
        }
    }
}