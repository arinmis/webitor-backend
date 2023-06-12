using Core.Features.Files.Commands;
using Core.Features.Files.Queries.GetAllFiles;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Core.Wrappers;
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
        [HttpGet("{projectName}/{path}")]
        public async Task<IActionResult> GetFile(string projectName, string path)
        {
            return Ok(await Mediator.Send(new GetFileCommand
            {
                projectName = projectName,
                path = $"/{path}"
            }));
        }

        /// <summary>
        /// Returns all of the file that belongs to given project created by Authorized user
        /// </summary>
        /// <returns>The requested item.</returns>
        [HttpGet("{projectName}")]
        public async Task<IActionResult> Get(string projectName)
        {
            return Ok(await Mediator.Send(new GetAllFiles() { projectName = projectName }));
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
            Response<string> response = await Mediator.Send(command);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);
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
        [HttpDelete("{projectName}/{path}")]
        public async Task<IActionResult> Delete(string projectName, string path)
        {
            return Ok(await Mediator.Send(new DeleteFileCommand
            {
                projectName = projectName,
                path = $"/{path}"
            }));
        }
    }
}
