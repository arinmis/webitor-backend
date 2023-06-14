
using Core.Features.Collaborator.Commands;
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
    public class CollaboratorController : BaseApiController
    {

        /// <summary>
        ///  
        /// </summary>
        /// <remarks>
        /// Sample request:
        /// 
        ///     POST api/project 
        ///     {        
        ///         "projectName": "webitor"",
        ///         "collaboratorUserName": "Arinmis123."":   
        ///     }
        /// </remarks>
        [HttpPost]
        public async Task<IActionResult> AddCollaborator(AddCollaboratorCommand command)
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