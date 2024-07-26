using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static FitnessJournal.Application.Dto.ProfileDto;

namespace FitnessJournal.Application.Command_Queries.userAchievement
{
    public class AddAchievementCommand : IRequest<CommonResponse>
    {
        public AddAchievementDto Dto { get; set; }
    }

    public class AddAchievementCommandHandler : IRequestHandler<AddAchievementCommand, CommonResponse>
    {
        private readonly IGenericRepository<Achievement> _repository;
        private readonly IMapper _mapper;

        public AddAchievementCommandHandler(IGenericRepository<Achievement> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CommonResponse> Handle(AddAchievementCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.Dto;
                var newAchievement = new Achievement
                {
                    Title = dto.Title,
                    Description = dto.Description,
                    DateAchieved = DateTime.Now
                    
                };

                var response = await _repository.AddAsync(newAchievement);
                return new CommonResponse
                {
                    Id = response.Id,
                    Success = true,
                    Message = "Record Created Successfully"
                };

            }
            catch (Exception )
            {
                return new CommonResponse
                {
                    Id = 0,
                    Success = false,
                    Message = "Failed to Save."

                };
            }
        }
    }
}
