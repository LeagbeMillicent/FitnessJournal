using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;


namespace FitnessJournal.Application.Command_Queries.userGoal
{
    public class AddGoalCommand : IRequest<CommonResponse>
    {
        public AddGoalDto AddGoalDto { get; set; }
    }

    public class AddGoalCommandHandler : IRequestHandler<AddGoalCommand, CommonResponse>
    {
        private readonly IGenericRepository<Goal> _repository;
        private readonly IMapper _mapper;

        public AddGoalCommandHandler(IGenericRepository<Goal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CommonResponse> Handle(AddGoalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.AddGoalDto;
                var newGoal = new Goal
                {
                    GoalName = dto.GoalName,
                    Workout = dto.Workout                    
                };

                var response = await _repository.AddAsync(newGoal);
                return new CommonResponse
                {
                    Id = response.GoalId,
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
