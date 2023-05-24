using System;
using Core.DTOs.File;
using Core.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Core.Features.Files.Commands.CreateFile;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FileController : ControllerBase
    {
        private readonly ICreateFileCommandHandler _createFileCommandHandler;
        public FileController(ICreateFileCommandHandler createFileCommandHandler)
        {
            _createFileCommandHandler = createFileCommandHandler;
        }

        [Authorize]
        [HttpPost("create-file")]
        public async Task<string> CreateFileAsync(CreateFileCommand request)
        {
            return  await _createFileCommandHandler.Handle(request);
        }


        private string GenerateIPAddress()
        {
            if (Request.Headers.ContainsKey("X-Forwarded-For"))
                return Request.Headers["X-Forwarded-For"];
            else
                return HttpContext.Connection.RemoteIpAddress.MapToIPv4().ToString();
        }

    }
}
