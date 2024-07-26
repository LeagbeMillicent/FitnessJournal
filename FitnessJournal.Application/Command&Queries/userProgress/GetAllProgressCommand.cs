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
    public class GetAllProgressCommand : IRequest<IReadOnlyList<ProgressDto>>
    {
    }

    public class ProgressCommandGetAllHandler : IRequestHandler<GetAllProgressCommand, IReadOnlyList<ProgressDto>>
    {
        private readonly IGenericRepository<Progress> _repository;
        private readonly IMapper _mapper;

        public ProgressCommandGetAllHandler(IGenericRepository<Progress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<ProgressDto>> Handle(GetAllProgressCommand request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<ProgressDto>>(data);
        }
    }
}
