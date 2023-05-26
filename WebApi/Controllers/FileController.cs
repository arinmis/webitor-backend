using Core.Features.Files.Commands.CreateFile;
using Core.Features.Files.Commands.DeleteFileWithPath;
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

namespace WebApi.Controllers
{

    [ApiVersion("1.0")]
    [Authorize]
    public class FileController : BaseApiController
    {

        /// <summary>
        /// Returns specific file created by Authorized user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     GET api/file/foo/bar.py 
        ///     {        
        ///     }
        /// </remarks>
        [HttpGet("{path}")]
        public async Task<IActionResult> GetFile(string path)
        {
            return Ok(await Mediator.Send(new GetFileWithPath
            {
                path = $"/{path}"
            }));
        }

        /// <summary>
        /// Returns all of the file created by Authorized user
        /// </summary>
        /// <returns>The requested item.</returns>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllFiles()));
        }

        /// <summary>
        /// Creates file with  file path and content for  Authorized user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/file/foo/bar.py 
        ///     {        
        ///         "path": "/foo/bar.py",
        ///         "content": "random_integer = random.randint(1, 100)"
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> Post(CreateFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Updates file path and content for  Authorized user
        /// </summary>
        /// <remarks>
        /// To update file path, pass existing content and change new path:
        ///     PUT api/file/foo/bar.py 
        ///      {
        ///         "oldPath": "/foo/bar.py",
        ///         "newPath": "/foo/baz.txt",
        ///         "content": "random_integer = random.randint(1, 100)"
        ///      }
        /// To update file content, use same file path and just change content:
        /// 
        ///     PUT api/file/foo/bar.py 
        ///      {
        ///         "oldPath": "/foo/bar.py",
        ///         "newPath": "/foo/bar.py",
        ///         "content": "random_integer = [randint(0, 9) for p in range(0, 10)]"
        ///      }
        /// </remarks>
        [HttpPut("")]
        public async Task<IActionResult> Put(UpdateFileCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

        /// <summary>
        /// Deletes file that has given path for  Authorized user
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/file/foo/bar.py 
        ///     {        
        ///     }
        /// </remarks>
        [HttpDelete("{path}")]
        public async Task<IActionResult> Delete(string path)
        {
            return Ok(await Mediator.Send(new DeleteFileWithPathCommand { path = $"/{path}" }));
        }
    }
}
