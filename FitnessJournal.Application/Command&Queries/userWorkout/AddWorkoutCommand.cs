using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;
using System.Text;

namespace FitnessJournal.Application.Command_Queries.userWorkout
{
    public class AddWorkoutCommand : IRequest<CommonResponse>
    {
        public AddWorkoutDto AddWorkDto { get; set; }
        public  byte[]? Image {  get; set; }
    }

    public class AddWorkoutCommandHandler : IRequestHandler<AddWorkoutCommand, CommonResponse>
    {
        private readonly IGenericRepository<Workout> _repository;
        private readonly IMapper _mapper;

        public AddWorkoutCommandHandler(IGenericRepository<Workout> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CommonResponse> Handle(AddWorkoutCommand request, CancellationToken cancellationToken)
        {
            try
            {
                
                var dto = request.AddWorkDto;

               
                var newData = new Workout
                {
                    
                    Name = dto.Name,
                    Duration = dto.Duration,
                    Intensity = dto.Intensity,
                    Image = request.Image,
                    StartTime = DateTime.Now.AddMinutes(-60),
                    EndTime = DateTime.Now,
                    Rmks = dto.Rmks
                    
                };

                var response = await _repository.AddAsync(newData);
                return new CommonResponse
                {
                    Id = response.Id,
                    Success = true,
                    Message = "Record Created Successfully"
                };

            }
            catch (Exception )
            {
                return new CommonResponse
                {
                    Id = 0,
                    Success = false,
                    Message = "Failed to Save."

                };
            }
        }
    }
}
