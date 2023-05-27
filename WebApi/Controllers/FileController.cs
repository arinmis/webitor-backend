using Core.Features.Files.Commands.CreateFile;
using Core.Features.Files.Commands.DeleteFileWithPath;
using Core.Features.Files.Commands.UpdateFile;
using Core.Features.Files.Queries.GetAllFiles;
using Core.Features.Files.Queries.GetFileWithPath;
using Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers.v1
{

    [ApiVersion("1.0")]
    [Authorize]
    public class FileController : BaseApiController
    {

        [HttpGet("{path}")]
        public async Task<IActionResult> GetFile(string path)
        {
            return Ok(await Mediator.Send(new GetFileWithPath
            {
                path = $"/{path}"
            }));
        }


        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllFiles()));
        }

        // POST api/<controller>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // PUT api/<controller>/5
        [HttpPut("{path}")]
        public async Task<IActionResult> Put(string path, UpdateFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        // DELETE api/<controller>/5
        [HttpDelete("{path}")]
        public async Task<IActionResult> Delete(string path)
        {
            return Ok(await Mediator.Send(new DeleteFileWithPathCommand { path = $"/{path}" }));
        }
    }
}
