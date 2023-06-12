using AutoMapper;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Projects.Commands
{
    public partial class UpdateProjectCommand : IRequest<Response<string>>
    {
        public string newName { get; set; }
        public string oldName { get; set; }
    }

    public class UpdateProjectCommandHandler : IRequestHandler<UpdateProjectCommand, Response<string>>
    {
        private readonly IProjectRepositoryAsync _projectRepository;
        private readonly IMapper _mapper;
        public UpdateProjectCommandHandler(IProjectRepositoryAsync projectRepository, IMapper mapper)
        {
            _projectRepository = projectRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(UpdateProjectCommand request, CancellationToken cancellationToken)
        {
            var project = await _projectRepository.GetProjectWithNameAsync(request.oldName);
            project.Name = request.newName;
            await _projectRepository.UpdateAsync(project);
            return new Response<string>
            {
                Succeeded = true,
                Data = project.Name,
                Message = $"project is updated with name: {project.Name}"
            };
        }
    }
}