using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.userProfile;
using FitnessJournal.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessJournal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UserProfileController : ControllerBase
    {
        private readonly IMediator _medator;
        public UserProfileController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProfile([FromBody] AddProfileDto dto)
        {
            var command = new AddProfileCommand { AddProfileDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProfile([FromBody] UpdateProfileDto dto)
        {
            var command = new UpdateProfileCommand { UpdateProfileDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteProfile([FromQuery] int id)
        {
            var response = await _medator.Send(new DeleteProfileCommand { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProfiles()
        {
            var result = await _medator.Send(new ProfileCommandGetAll());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetProfileById([FromQuery] int id)
        {
            var result = await _medator.Send(new GetProfileByIdCommand { Id = id });
            return Ok(result);
        }
    }
}
