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
    public class UpdateProgressCommand : IRequest<CommonResponse>
    {
        public UpdateProgressDto UpdateProDto { get; set; }
    }

    public class UpdateProgressCommandHandler : IRequestHandler<UpdateProgressCommand, CommonResponse>
    {
        private readonly IGenericRepository<Progress> _repository;
        private readonly IMapper _mapper;

        public UpdateProgressCommandHandler(IGenericRepository<Progress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> Handle(UpdateProgressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.UpdateProDto;
                var entity = _mapper.Map<Progress>(dto);

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
