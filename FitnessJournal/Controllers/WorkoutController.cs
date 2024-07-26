using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.userProfile;
using FitnessJournal.Application.Command_Queries.userWorkout;
using FitnessJournal.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FitnessJournal.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class WorkoutController : ControllerBase
    {
        private readonly IMediator _medator;
        public WorkoutController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddWorkOut([FromBody] AddWorkoutDto dto)
        {
            var command = new AddWorkoutCommand { AddWorkDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateWorkout([FromBody] UpdateWorkoutDto dto)
        {
            var command = new UpdateWorkoutCommand { UpdateWorkDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteWorkout([FromQuery] int id)
        {
            var response = await _medator.Send(new DeleteWorkoutCommand { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllWorkout()
        {
            var result = await _medator.Send(new WorkoutCommandGetAll());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetWorkoutById([FromQuery] int id)
        {
            var result = await _medator.Send(new GetWorkoutByIdCommand { Id = id });
            return Ok(result);
        }
    }
}
