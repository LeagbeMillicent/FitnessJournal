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

namespace FitnessJournal.Application.Command_Queries.userProfile
{
    public class GetAllProfileCommand : IRequest<IReadOnlyList<ProfileDto>>
    {
    }

    public class GetAllProfileCommandHandlerHandler : IRequestHandler<GetAllProfileCommand, IReadOnlyList<ProfileDto>>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public GetAllProfileCommandHandlerHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProfileDto>> Handle(GetAllProfileCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProfileDto>>(data);
        }
    }
}
