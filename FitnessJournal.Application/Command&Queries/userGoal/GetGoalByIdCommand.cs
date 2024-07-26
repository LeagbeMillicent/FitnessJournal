using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;

namespace FitnessJournal.Application.Command_Queries.userGoal
{
    public class GetGoalByIdCommand : IRequest<GoalDto>
    {
        public int Id { get; set; }
    }
    public class GetGoalByIdCommandHandler : IRequestHandler<GetGoalByIdCommand, GoalDto>
    {
        private readonly IGenericRepository<Goal> _repository;
        private readonly IMapper _mapper;

        public GetGoalByIdCommandHandler(IGenericRepository<Goal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<GoalDto> Handle(GetGoalByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<GoalDto>(data);
        }
    }
}
