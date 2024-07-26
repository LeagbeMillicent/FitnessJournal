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
    public class FitnessCommandGetAll : IRequest<IReadOnlyList<FitnessInfoDto>>
    {

    }

    public class FitnessCommandGetAllHandler : IRequestHandler<FitnessCommandGetAll, IReadOnlyList<FitnessInfoDto>>
    {
        private readonly IGenericRepository<FitnessInformation> _repository;
        private readonly IMapper _mapper;

        public FitnessCommandGetAllHandler(IGenericRepository<FitnessInformation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<IReadOnlyList<FitnessInfoDto>> Handle(FitnessCommandGetAll request, CancellationToken cancellationToken)
        {
            var data = await _repository.GetAllAsync();
            return _mapper.Map<List<FitnessInfoDto>>(data);
        }
    }
}
