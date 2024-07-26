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

namespace FitnessJournal.Application.Command_Queries.userProgress
{
    public class AddProgressCommand : IRequest<CommonResponse>
    {
        public AddProgressDto AddProDto { get; set; }
    }

    public class AddProgressCommandHandler : IRequestHandler<AddProgressCommand, CommonResponse>
    {
        private readonly IGenericRepository<Progress> _repository;
        private readonly IMapper _mapper;

        public AddProgressCommandHandler(IGenericRepository<Progress> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CommonResponse> Handle(AddProgressCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.AddProDto;
                var newProgress = new Progress
                {
                    Date = dto.Date,
                    Weight = dto.Weight,
                    WorkoutStats = dto.WorkoutStats,
                    Rmks = dto.Rmks
                };

                var response = await _repository.AddAsync(newProgress);
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
                    Message = "Faild to Save ."

                };
            }
        }
    }
}
