using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.userGoal;
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
    public class GoalController : ControllerBase
    {
        private readonly IMediator _medator;
        public GoalController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddGoal([FromBody] AddGoalDto dto)
        {
            var command = new AddGoalCommand { AddGoalDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateGoal([FromBody] UpdateGoalDto dto)
        {
            var command = new UpdateGoalCommand { UpdateGoalDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteGoal([FromQuery] int id)
        {
            var response = await _medator.Send(new DeleteGoalCommand { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllGoals()
        {
            var result = await _medator.Send(new GoalCommandGetAll());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetGoalById([FromQuery] int id)
        {
            var result = await _medator.Send(new GetGoalByIdCommand { Id = id });
            return Ok(result);
        }
    }
}
