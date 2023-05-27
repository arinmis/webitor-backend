using Core.Features.Files.Commands.CreateFile;
using Core.Features.Files.Commands.DeleteFileWithPath;
using Core.Features.Repository.Commands.DownloadRepository;
using Core.Features.Files.Commands.UpdateFile;
using Core.Features.Files.Queries.GetAllFiles;
using Core.Features.Files.Queries.GetFileWithPath;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    [Authorize]
    public class RepositoryController : BaseApiController
    {

        /// <summary>
        /// Downloads whole repository as a zip file for authenticated user 
        /// </summary>
        [HttpGet("download")]
        public async Task<IActionResult> DownloadRepository()
        {
            // return File(await Mediator.Send(command), "application/zip", "fileName.zip"); // Ok(await Mediator.Send(new GetAllFiles()));
            var response = await Mediator.Send(new DownloadRepositoryCommand());
            string now = DateTime.Now.ToString("dd/MM/yyyy-HH:mm");
            return File(response.Data, "application/zip", $"repository-{now}.zip");
        }
    }
}
