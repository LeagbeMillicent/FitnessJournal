using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;

namespace FitnessJournal.Application.Command_Queries.userAchievement
{
    public class GetAchievementByIdCommand : IRequest<AchievementDto>
    {
        public int Id { get; set; }
    }
    public class GetAchievementByIdCommandHandler : IRequestHandler<GetAchievementByIdCommand, AchievementDto>
    {
        private readonly IGenericRepository<Achievement> _repository;
        private readonly IMapper _mapper;

        public GetAchievementByIdCommandHandler(IGenericRepository<Achievement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<AchievementDto> Handle(GetAchievementByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<AchievementDto>(data);
        }
    }
}
