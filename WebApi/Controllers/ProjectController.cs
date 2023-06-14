using Core.Features.Projects.Commands;
using Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Core.Features.Projects.Queries;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WebApi.Controllers
{

    [ApiVersion("1.0")]
    [Authorize]
    public class ProjectController : BaseApiController
    {

        /// <summary>
        /// Downloads whole repository as a zip file for authenticated user 
        /// </summary>
        [HttpGet("download/{projectId}")]
        public async Task<IActionResult> DownloadProject(int projectId)
        {
            // return File(await Mediator.Send(command), "application/zip", "fileName.zip"); // Ok(await Mediator.Send(new GetAllFiles()));
            var response = await Mediator.Send(new DownloadProjectCommand { projectId = projectId });
            string now = DateTime.Now.ToString("dd/MM/yyyy-HH:mm");
            return File(response.Data, "application/zip", $"project-{now}.zip");
        }


        /// <summary>
        /// create new  for authenticated user 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/project 
        ///     {        
        ///         "name": "init_project"",
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> CreateProject(CreateProjectCommand command)
        {

            Response<int> response = await Mediator.Send(command);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }


        /// <summary>
        /// Returns all projects created by Authorized user 
        /// </summary>
        /// <returns>The requested item.</returns>
        [HttpGet("")]
        public async Task<IActionResult> Get()
        {
            return Ok(await Mediator.Send(new GetAllProjects()));
        }


        /// <summary>
        /// Deletes project created by Authorized user 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     DELETE api/project/webitor 
        ///     {        
        ///     }
        /// </remarks>
        [HttpDelete("{projectId}")]
        public async Task<IActionResult> DeleteProject(int projectId)
        {
            return Ok(await Mediator.Send(new DeleteProjectCommand { projectId = projectId }));
        }

        /// <summary>
        /// Updates project created by Authorized user 
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     PUT api/project 
        ///     {        
        ///         "oldName": "webitor",
        ///         "newName": "webitor-2.0"
        ///     }
        /// </remarks>
        [HttpPut("")]
        public async Task<IActionResult> UpdateProject(UpdateProjectCommand command)
        {
            return Ok(await Mediator.Send(command));
        }

    }
}
