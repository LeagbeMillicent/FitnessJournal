using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.userProfile;
using FitnessJournal.Application.Command_Queries.userProgress;
using FitnessJournal.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessJournal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class ProgressController : ControllerBase
    {
        private readonly IMediator _medator;
        public ProgressController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddProgress([FromBody] AddProgressDto dto)
        {
            var command = new AddProgressCommand { AddProDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProgress([FromBody] UpdateProgressDto dto)
        {
            var command = new UpdateProgressCommand { UpdateProDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteProgress([FromQuery] int id)
        {
            var response = await _medator.Send(new DeleteProgressCommand { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllProgress()
        {
            var result = await _medator.Send(new GetAllProgressCommand());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetProgressById([FromQuery] int id)
        {
            var result = await _medator.Send(new GetProgressByIdCommand { Id = id });
            return Ok(result);
        }
    }
}
