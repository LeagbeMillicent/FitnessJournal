using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.FitnessInfo;
using FitnessJournal.Application.Command_Queries.userAchievement;
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
    public class AchievementController : ControllerBase
    {
        private readonly IMediator _medator;
        public AchievementController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddAchievement([FromBody] AddAchievementDto dto)
        {
            var command = new AddAchievementCommand { Dto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateAchievement([FromBody] UpdateAchievementDto dto)
        {
            var command = new UpdateAchievementCommand { UpdatDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteAchievement([FromQuery] int id)
        {
            var response = await _medator.Send(new DeleteAchievementCommand { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAchievement()
        {
            var result = await _medator.Send(new AchievementCommandGetAll());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetAchievementById([FromQuery] int id)
        {
            var result = await _medator.Send(new GetAchievementByIdCommand { Id = id });
            return Ok(result);
        }
    }
}
