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

namespace FitnessJournal.Application.Command_Queries.FitnessInfo
{
    public class ViewUserProfileGetCommand : IRequest<ViewProfileDto>
    {
        public int Id { get; set; }
    }

    public class ViewUserProfileGetCommandHandler : IRequestHandler<ViewUserProfileGetCommand, ViewProfileDto>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public ViewUserProfileGetCommandHandler(IGenericRepository<UserProfile> repository, IMapper mapper) 
        { _repository = repository;
            _mapper = mapper;
        }
        public async Task<ViewProfileDto> Handle(ViewUserProfileGetCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ViewProfileDto>(data);
        }
    }
}
