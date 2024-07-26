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
    public class ProfileCommandGetAll : IRequest<IReadOnlyList<ProfileDto>>
    {

    }

    public class ProfileCommandGetAllHandler : IRequestHandler<ProfileCommandGetAll, IReadOnlyList<ProfileDto>>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public ProfileCommandGetAllHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProfileDto>> Handle(ProfileCommandGetAll request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProfileDto>>(data);
        }
    }
}
