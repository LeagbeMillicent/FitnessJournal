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

namespace FitnessJournal.Application.Command_Queries.userAchievement
{
    public class UpdateAchievementCommand : IRequest<CommonResponse>
    {
        public UpdateAchievementDto UpdatDto { get; set; }
    }

    public class UpdateAchievementCommandHandler : IRequestHandler<UpdateAchievementCommand, CommonResponse>
    {
        private readonly IGenericRepository<Achievement> _repository;
        private readonly IMapper _mapper;

        public UpdateAchievementCommandHandler(IGenericRepository<Achievement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }
        public async Task<CommonResponse> Handle(UpdateAchievementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.UpdatDto;
                var entity = _mapper.Map<Achievement>(dto);

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
