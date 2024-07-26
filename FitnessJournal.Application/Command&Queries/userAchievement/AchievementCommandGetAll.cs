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

namespace FitnessJournal.Application.Command_Queries.userAchievement
{
    public class AchievementCommandGetAll : IRequest<IReadOnlyList<AchievementDto>>
    {

    }

    public class AchievementCommandGetAllHandler : IRequestHandler<AchievementCommandGetAll, IReadOnlyList<AchievementDto>>
    {
        private readonly IGenericRepository<Achievement> _repository;
        private readonly IMapper _mapper;

        public AchievementCommandGetAllHandler(IGenericRepository<Achievement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<AchievementDto>> Handle(AchievementCommandGetAll request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<AchievementDto>>(data);
        }
    }
}
