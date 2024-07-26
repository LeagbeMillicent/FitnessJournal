using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using MediatR;


namespace FitnessJournal.Application.Command_Queries.FitnessInfo
{
    public class AddFitnessCommand : IRequest<CommonResponse>
    {
        public AddFitnessInfoDto AddFitnessDto { get; set; }
    }

    public class AddFitnessCommandHandler : IRequestHandler<AddFitnessCommand, CommonResponse>
    {
        private readonly IGenericRepository<FitnessInformation> _repository;
        private readonly IMapper _mapper;

        public AddFitnessCommandHandler(IGenericRepository<FitnessInformation> repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;

        }
        public async Task<CommonResponse> Handle(AddFitnessCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var dto = request.AddFitnessDto;
                var newInfo = new FitnessInformation
                {
                    FitnessLevel = dto.FitnessLevel,
                    Goals = dto.Goals,
                    PreferredWorkoutTypes = dto.PreferredWorkoutTypes
                    
                };

                var response = await _repository.AddAsync(newInfo);
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
