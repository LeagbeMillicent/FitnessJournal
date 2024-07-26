using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;

namespace FitnessJournal.Application.Command_Queries.userProfile
{
    public class GetProfileByIdCommand : IRequest<ProfileDto>
    {
        public int Id { get; set; }
    }
    public class GetProfileByIdCommandHandler : IRequestHandler<GetProfileByIdCommand, ProfileDto>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public GetProfileByIdCommandHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProfileDto> Handle(GetProfileByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ProfileDto>(data);
        }
    }
}
