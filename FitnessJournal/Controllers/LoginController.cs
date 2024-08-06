using FitnessJournal.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessJournal.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly IMediator _mediatR;
        public LoginController(IMediator mediatR)
        {
            _mediatR = mediatR;
        }

        [HttpPost]
        public Task <IActionResult> Login([FromBody]LoginDto request)
        {
            return null;
        }
    }
}
