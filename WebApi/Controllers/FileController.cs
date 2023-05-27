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
        // // GET: api/<controller>
        // [HttpGet]
        // [ProducesResponseType(StatusCodes.Status200OK, Type = typeof(PagedResponse<IEnumerable<GetAllFilesViewModel>>))]
        // public async Task<PagedResponse<IEnumerable<GetAllFilesViewModel>>> Get([FromQuery] GetAllFilesParameter filter)
        // {
        //     return await Mediator.Send(new GetAllFilesQuery() { PageSize = filter.PageSize, PageNumber = filter.PageNumber, UserId = filter.UserId });
        // }

        // GET api/<controller>/5
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

        // // PUT api/<controller>/5
        // [HttpPut("{id}")]
        // public async Task<IActionResult> Put(int id, UpdateFileCommand command)
        // {
        //     if (id != command.Id)
        //     {
        //         return BadRequest();
        //     }
        //     return Ok(await Mediator.Send(command));
        // }

        // DELETE api/<controller>/5
        [HttpDelete("{path}")]
        public async Task<IActionResult> Delete(string path)
        {
            return Ok(await Mediator.Send(new DeleteFileWithPathCommand { path = $"/{path}" }));
        }
    }
}
