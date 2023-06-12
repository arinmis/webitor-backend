using Core.Features.Projects.Commands;
using Core.Wrappers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
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

        // /// <summary>
        // /// Downloads whole repository as a zip file for authenticated user 
        // /// </summary>
        // [HttpGet("download")]
        // public async Task<IActionResult> DownloadProject(DownloadProjectCommand command)
        // {
        //     // return File(await Mediator.Send(command), "application/zip", "fileName.zip"); // Ok(await Mediator.Send(new GetAllFiles()));
        //     var response = await Mediator.Send(command);
        //     string now = DateTime.Now.ToString("dd/MM/yyyy-HH:mm");
        //     return File(response.Data, "application/zip", $"project-{now}.zip");
        // }


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

            Response<string> response = await Mediator.Send(command);
            if (response.Succeeded)
            {
                return Ok(response);
            }
            return BadRequest(response);

        }

    }
}
