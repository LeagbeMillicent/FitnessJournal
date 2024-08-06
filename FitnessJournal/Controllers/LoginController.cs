using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessJournal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public LoginController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public async Task <IActionResult> Login([FromBody]LoginDto request)
        {
            var command = new LoginCommand { LoginDto = request };  
            var response = await _mediatR.Send(command);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> RegisterUser([FromBody] RegisterDto requst)
        {
            var command = new RegisterCommand { RegisterDto = requst };
            var response = await _mediatR.Send(command);
            if (response == null)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }
    }
}
