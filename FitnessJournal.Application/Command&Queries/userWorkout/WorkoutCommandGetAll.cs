using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Command_Queries.userWorkout
{
    public class WorkoutCommandGetAll : IRequest<IReadOnlyList<WorkoutDto>>
    {

    }

    public class WorkoutCommandGetAllHandler : IRequestHandler<WorkoutCommandGetAll, IReadOnlyList<WorkoutDto>>
    {
        private readonly IGenericRepository<Workout> _repository;
        private readonly IMapper _mapper;

        public WorkoutCommandGetAllHandler(IGenericRepository<Workout> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<WorkoutDto>> Handle(WorkoutCommandGetAll request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<WorkoutDto>>(data);
        }
    }
}
