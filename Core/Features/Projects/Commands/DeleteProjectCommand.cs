using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Projects.Commands
{
    public class DeleteProjectCommand : IRequest<Response<int>>
    {
        public int projectId { get; set; }
        public class DeleteProjectCommandHandler : IRequestHandler<DeleteProjectCommand, Response<int>>
        {
            private readonly IProjectRepositoryAsync _projectRepository;
            public DeleteProjectCommandHandler(IProjectRepositoryAsync projectRepository)
            {
                _projectRepository = projectRepository;
            }
            public async Task<Response<int>> Handle(DeleteProjectCommand command, CancellationToken cancellationToken)
            {
                var project = await _projectRepository.GetProjectWithIdAsync(command.projectId);
                if (project == null) throw new ApiException($"Project Not Found.");
                await _projectRepository.DeleteAsync(project);
                return new Response<int> { Data = project.Id, Message = "Project deleted" };
            }
        }
    }
}
