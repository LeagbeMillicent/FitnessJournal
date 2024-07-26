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

namespace FitnessJournal.Application.Command_Queries.userGoal
{
    public class GoalCommandGetAll : IRequest<IReadOnlyList<GoalDto>>
    {

    }

    public class GoalCommandGetAllHandler : IRequestHandler<GoalCommandGetAll, IReadOnlyList<GoalDto>>
    {
        private readonly IGenericRepository<Goal> _repository;
        private readonly IMapper _mapper;

        public GoalCommandGetAllHandler(IGenericRepository<Goal> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<GoalDto>> Handle(GoalCommandGetAll request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<GoalDto>>(data);
        }
    }
}
