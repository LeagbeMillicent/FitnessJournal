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

namespace FitnessJournal.Application.Command_Queries.userProgress
{
    public class GetProgressByIdCommand : IRequest<ProgressDto>
    {
        public int Id { get; set; }
    }
    public class GetProgressByIdCommandHandler : IRequestHandler<GetProgressByIdCommand, ProgressDto>
    {
        private readonly IGenericRepository<Progress> _repository;
        private readonly IMapper _mapper;

        public GetProgressByIdCommandHandler(IGenericRepository<Progress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<ProgressDto> Handle(GetProgressByIdCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetByIdAsync(request.Id);
            return _mapper.Map<ProgressDto>(data);
        }
    }
}
