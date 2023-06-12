using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<Response<string>>
    {
        public string projectName { get; set; }
        public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Response<string>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public DeleteProjectCommandHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<string>> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetProjectWithNameAsync(command.projectName);
                if (project == null) throw new ApiException($"Project Not Found.");
                await _projectRepository.DeleteAsync(project);
                return new Response<string> { Data = project.Name, Message = "Project deleted" };
            }
        }
    }
}
