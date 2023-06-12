using Core.Exceptions;
using System.Collections.Generic;
using Core.Entities;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;

namespace Core.Features.Files.Commands
{
    public class MoveFilesCommand : IRequest<Response<List<string>>>
    {
        public string projectName { get; set; }
        public string oldFolder { get; set; }
        public string newFolder { get; set; }
        public class MoveFilesCommandHandler : IRequestHandler<MoveFilesCommand, Response<List<string>>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public MoveFilesCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<List<string>>> Handle(MoveFilesCommand command, CancellationToken cancellationToken)
            {
                List<string> filePaths = new List<string>();
                var files = await _fileRepository.GetFilesInFolderAsync(command.projectName, command.oldFolder);
                foreach (File file in files)
                {
                    file.Path = file.Path.Replace(command.oldFolder, command.newFolder);
                    filePaths.Add(file.Path);
                    await _fileRepository.UpdateAsync(file);
                }

                return new Response<List<string>>
                {
                    Data = filePaths,
                    Succeeded = true,
                };
            }
        }
    }
}