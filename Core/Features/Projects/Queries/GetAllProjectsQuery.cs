
using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Core.Features.Projects.Queries
{
    public class GetAllProjects : IRequest<Response<IReadOnlyList<Project>>>
    {
        public class GetAllProjectsQueryHandler : IRequestHandler<GetAllProjects, Response<IReadOnlyList<Project>>>
        {
            private readonly IProjectRepositoryAsync _projectsRepository;
            public GetAllProjectsQueryHandler(IProjectRepositoryAsync projectsRepository)
            {
                _projectsRepository = projectsRepository;
            }
            public async Task<Response<IReadOnlyList<Project>>> Handle(GetAllProjects request, CancellationToken cancellationToken)
            {
                var projects = await _projectsRepository.GetAllProjectsAsync();
                // if (files == null) throw new ApiException($"File Not Found.");
                return new Response<IReadOnlyList<Project>>(projects);
            }
        }
    }
}