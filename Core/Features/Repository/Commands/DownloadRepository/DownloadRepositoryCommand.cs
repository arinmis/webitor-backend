using Core.Exceptions;
using Core.Interfaces.Repositories;
using Core.Wrappers;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using System;
using System.Collections.Generic;
using System.IO.Compression;
using MemoryStream = System.IO.MemoryStream;
using Stream = System.IO.Stream;
using StreamWriter = System.IO.StreamWriter;
using IOException = System.IO.IOException;
using Core.Entities;

namespace Core.Features.Repository.Commands.DownloadRepository
{
    public class DownloadRepositoryCommand : IRequest<Response<byte[]>>

    {

        private static byte[] CreateZipFile(IReadOnlyList<File> files)
        {
            using (MemoryStream memoryStream = new MemoryStream())
            {
                using (ZipArchive zipArchive = new ZipArchive(memoryStream, ZipArchiveMode.Create, true))
                {
                    foreach (File file in files)
                    {
                        ZipArchiveEntry entry = zipArchive.CreateEntry(file.Path);

                        using (Stream entryStream = entry.Open())
                        using (StreamWriter writer = new StreamWriter(entryStream))
                        {
                            writer.Write(file.Content);
                        }
                    }
                }

                return memoryStream.ToArray();
            }
        }

        public class DownloadRepositoryCommandHandler : IRequestHandler<DownloadRepositoryCommand, Response<byte[]>>
        {
            private readonly IFileRepositoryAsync _fileRepository;
            public DownloadRepositoryCommandHandler(IFileRepositoryAsync fileRepository)
            {
                _fileRepository = fileRepository;
            }
            public async Task<Response<byte[]>> Handle(DownloadRepositoryCommand command, CancellationToken cancellationToken)
            {

                IReadOnlyList<File> files = await _fileRepository.GetAllFilesAsync();
                byte[] zippedFiles = CreateZipFile(files);
                return new Response<byte[]>(zippedFiles); // new Response<string> { Data = file.Path, Message = "File deleted" };
            }
        }
    }
}
