using FitnessJournal.Application.Command_Queries;
using FitnessJournal.Application.Command_Queries.userProfile;
using FitnessJournal.Application.Command_Queries.userWorkout;
using FitnessJournal.Application.Dto;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Net.Mime;

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
        [Consumes("multipart/form-data")]
        public async Task<IActionResult> AddWorkOut([FromForm] AddWorkoutDto dto, IFormFile? image)
        {
            byte[]? imageBytes = null;

            if (image != null && image.Length > 0)
            {
                using (var ms = new MemoryStream())
                {
                    await image.CopyToAsync(ms);
                    imageBytes = ms.ToArray();
                }
            }

            var command = new AddWorkoutCommand { AddWorkDto = dto ,
                Image = imageBytes
            };
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
