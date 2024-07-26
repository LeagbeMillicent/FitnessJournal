using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.FitnessInfo;
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
    public class FitnessInfoController : ControllerBase
    {
        private readonly IMediator _medator;
        public FitnessInfoController(IMediator mediator)
        {
            _medator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> AddFitnessInformation([FromBody] AddFitnessInfoDto dto)
        {
            var command = new AddFitnessCommand { AddFitnessDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateFitnessInformation([FromBody] UpdateFitnessInfoDto dto)
        {
            var command = new UpdateFitnessCommand { UpdateFitDto = dto };
            var response = await _medator.Send(command);
            if (response.Success)
            {
                return Ok(response);
            }
            return BadRequest(response);
        }

        [HttpDelete("Id")]
        public async Task<IActionResult> DeleteFitnessInformation([FromQuery] int id)
        {
            var response = await _medator.Send(new DeleteFitnessCommand { Id = id });
            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllFitnessInformation()
        {
            var result = await _medator.Send(new FitnessCommandGetAll());
            return Ok(result);
        }

        [HttpGet("Id")]
        public async Task<IActionResult> GetFitnessInformationById([FromQuery] int id)
        {
            var result = await _medator.Send(new GetFitnessByIdCommand { Id = id });
            return Ok(result);
        }
    }
}
