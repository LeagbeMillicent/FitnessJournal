using AutoMapper;
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
    public class UpdateProfileCommand : IRequest<CommonResponse>
    {
        public UpdateProfileDto UpdateProfileDto { get; set; }
    }

    public class UpdateProfileCommandHandler : IRequestHandler<UpdateProfileCommand, CommonResponse>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public UpdateProfileCommandHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> Handle(UpdateProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.UpdateProfileDto;
                var entity = _mapper.Map<UserProfile>(dto);

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
