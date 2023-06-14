using AutoMapper;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using Core.Entities;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Core.Features.Collaborator.Commands
{
    public partial class AddCollaboratorCommand : IRequest<Response<string>>
    {
        public string projectId { get; set; }
        public string collaboratorUsername { get; set; }
    }

    public class AddCollaboratordCommandHandler : IRequestHandler<AddCollaboratorCommand, Response<string>>
    {
        private readonly ICollaboratorRepositoryAsync _collaboratorRepository;
        private readonly IMapper _mapper;
        public AddCollaboratordCommandHandler(ICollaboratorRepositoryAsync collaboratorRepository, IMapper mapper)
        {
            _collaboratorRepository = collaboratorRepository;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(AddCollaboratorCommand command, CancellationToken cancellationToken)
        {
            var collaborator = await _collaboratorRepository.AddCollaborator(command.projectId, command.collaboratorUsername);
            return new Response<string> { Succeeded = true, Data = collaborator.ProjectId, Message = $"collaboration is created" };
        }
    }
}
