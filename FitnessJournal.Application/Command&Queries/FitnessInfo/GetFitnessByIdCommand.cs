using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;

namespace FitnessJournal.Application.Command_Queries.FitnessInfo
{
    public class GetFitnessByIdCommand : IRequest<FitnessInfoDto>
    {
        public int Id { get; set; }
    }
    public class GetFitnessByIdCommandHandler : IRequestHandler<GetFitnessByIdCommand, FitnessInfoDto>
    {
        private readonly IGenericRepository<FitnessInformation> _repository;
        private readonly IMapper _mapper;

        public GetFitnessByIdCommandHandler(IGenericRepository<FitnessInformation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<FitnessInfoDto> Handle(GetFitnessByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<FitnessInfoDto>(data);
        }
    }
}
