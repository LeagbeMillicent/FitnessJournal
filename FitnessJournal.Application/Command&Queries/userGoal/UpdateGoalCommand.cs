using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;


namespace FitnessJournal.Application.Command_Queries.userGoal
{
    public class UpdateGoalCommand : IRequest<CommonResponse>
    {
        public UpdateGoalDto UpdateGoalDto { get; set; }
    }

    public class UpdateGoalCommandHandler : IRequestHandler<UpdateGoalCommand, CommonResponse>
    {
        private readonly IGenericRepository<Goal> _repository;
        private readonly IMapper _mapper;

        public UpdateGoalCommandHandler(IGenericRepository<Goal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> Handle(UpdateGoalCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.UpdateGoalDto;
                var entity = _mapper.Map<Goal>(dto);

                var data = await _repository.GetByIdAsync(entity.GoalId) ?? throw new KeyNotFoundException($"Entity with Id {dto.GoalName} not found.");

                _mapper.Map(dto, data);
                await _repository.UpdateAsync(data);
                return new CommonResponse { 
                    Success = true,
                    Message ="Updated Successfully"
                };
            }
            catch (Exception)
            {
                return new CommonResponse
                {
                    Success = false,
                    Message = "Faild to Update"
                };
            }
        }
    }
}
