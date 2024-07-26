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
    public class UpdateFitnessCommand : IRequest<CommonResponse>
    {
        public UpdateFitnessInfoDto UpdateFitDto { get; set; }
    }

    public class UpdateFitnessCommandHandler : IRequestHandler<UpdateFitnessCommand, CommonResponse>
    {
        private readonly IGenericRepository<FitnessInformation> _repository;
        private readonly IMapper _mapper;

        public UpdateFitnessCommandHandler(IGenericRepository<FitnessInformation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> Handle(UpdateFitnessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.UpdateFitDto;
                var entity = _mapper.Map<FitnessInformation>(dto);

                var data = await _repository.GetByIdAsync(entity.Id) ?? throw new KeyNotFoundException($"Entity with Id {dto.Id} not found.");

                _mapper.Map(dto, data);
                await _repository.UpdateAsync(data);
                return new CommonResponse { 
                    Success = true,
                    Message ="Updated Successfully"
                };
            }
            catch (Exception)
            {
                return new CommonResponse
                {
                    Success = false,
                    Message = "Faild to Update"
                };
            }
        }
    }
}
