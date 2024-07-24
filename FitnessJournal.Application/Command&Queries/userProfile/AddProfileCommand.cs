using AutoMapper;
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

namespace FitnessJournal.Application.Command_Queries
{
    public class AddProfileCommand : IRequest<CommonResponse>
    {
        public AddProfileDto AddProfileDto { get; set; }
    }

    public class AddProfileCommandHandler : IRequestHandler<AddProfileCommand, CommonResponse>
    {
        private readonly IGenericRepository<UserProfile> _repository;
        private readonly IMapper _mapper;

        public AddProfileCommandHandler(IGenericRepository<UserProfile> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CommonResponse> Handle(AddProfileCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.AddProfileDto;
                var newProfile = new UserProfile
                {
                    Name = dto.Name,
                    Email = dto.Email,
                    Password = dto.Password,
                    Age = dto.Age,
                    Gender = dto.Gender,
                    Height = dto.Height,
                    Weight = dto.Height,
                    CreatedDate = dto.CreatedDate,
                    LastUpdatedDate = dto.LastUpdatedDate
                };

                var response = await _repository.AddAsync(newProfile);
                return new CommonResponse
                {
                    Id = response.Id,
                    Success = true,
                    Message = "Record Created Successfully"
                };

            }
            catch (Exception ex)
            {
                return new CommonResponse
                {
                    Id = 0,
                    Success = false,
                    Message = ex.Message

                };
            }
        }
    }
}
