using AutoMapper;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Collaborator.Commands
{
    public partial class AddCollaboratorCommand : IRequest<Response<int>>
    {
        public int projectId { get; set; }
        public string collaboratorUsername { get; set; }
    }

    public class AddCollaboratordCommandHandler : IRequestHandler<AddCollaboratorCommand, Response<int>>
    {
        private readonly ICollaboratorRepositoryAsync _collaboratorRepository;
        private readonly IMapper _mapper;
        public AddCollaboratordCommandHandler(ICollaboratorRepositoryAsync collaboratorRepository, IMapper mapper)
        {
            _collaboratorRepository = collaboratorRepository;
            _mapper = mapper;
        }

        public async Task<Response<int>> Handle(AddCollaboratorCommand command, CancellationToken cancellationToken)
        {
            var collaborator = await _collaboratorRepository.AddCollaborator(command.projectId, command.collaboratorUsername);
            return new Response<int> { Succeeded = true, Data = collaborator.ProjectId, Message = $"collaboration is created" };
        }
    }
}
