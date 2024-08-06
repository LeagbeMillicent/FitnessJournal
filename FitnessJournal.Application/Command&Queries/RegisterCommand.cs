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

namespace FitnessJournal.Application.Command_Queries
{
    public class RegisterCommand : IRequest<Dto.userProfile>
    {
        public RegisterDto RegisterDto { get; set; }
    }

    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, Dto.userProfile>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public RegisterCommandHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<Dto.userProfile> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var data = _mapper.Map<UserProfile>(request.RegisterDto);
                var response = await _repository.AddAsync(data);
                if(response == null)
                {
                    return null;
                }
               var result = _mapper.Map<Dto.userProfile>(response);
                return result;
            }
            catch (Exception ex)
            {
                return null;
            }
        }
    }
}
