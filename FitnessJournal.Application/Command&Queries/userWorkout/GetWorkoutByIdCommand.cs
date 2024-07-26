using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;

namespace FitnessJournal.Application.Command_Queries.userWorkout
{
    public class GetWorkoutByIdCommand : IRequest<WorkoutDto>
    {
        public int Id { get; set; }
    }
    public class GetWorkoutByIdCommandHandler : IRequestHandler<GetWorkoutByIdCommand, WorkoutDto>
    {
        private readonly IGenericRepository<Workout> _repository;
        private readonly IMapper _mapper;

        public GetWorkoutByIdCommandHandler(IGenericRepository<Workout> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<WorkoutDto> Handle(GetWorkoutByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<WorkoutDto>(data);
        }
    }
}
