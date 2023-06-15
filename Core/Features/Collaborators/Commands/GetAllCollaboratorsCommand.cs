using AutoMapper;
using System.Collections.Generic;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Collaborator.Commands
{
    public partial class GetAllCollaboratorCommand : IRequest<Response<IReadOnlyList<Entities.Collaborator>>>
    {
        public int projectId { get; set; }
    }

    public class GetAllCollaboratordCommandHandler : IRequestHandler<GetAllCollaboratorCommand, Response<IReadOnlyList<Entities.Collaborator>>>
    {
        private readonly ICollaboratorRepositoryAsync _collaboratorRepository;
        private readonly IMapper _mapper;
        public GetAllCollaboratordCommandHandler(ICollaboratorRepositoryAsync collaboratorRepository, IMapper mapper)
        {
            _collaboratorRepository = collaboratorRepository;
            _mapper = mapper;
        }

        public async Task<Response<IReadOnlyList<Entities.Collaborator>>> Handle(GetAllCollaboratorCommand command, CancellationToken cancellationToken)
        {
            var collaborators = await _collaboratorRepository.GetAllCollaborationsAsync(command.projectId);
            return new Response<IReadOnlyList<Entities.Collaborator>>
            {
                Succeeded = true,
                Data = collaborators,
                Message = $"collaboration is created"
            };
        }
    }
}
