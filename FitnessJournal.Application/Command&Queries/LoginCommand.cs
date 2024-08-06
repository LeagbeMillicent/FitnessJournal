using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using MediatR;
using MediatR.Pipeline;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Command_Queries
{
    public class LoginCommand : IRequest<UserDto>
    {
        public LoginDto LoginDto { get; set; }
    }

    public class LoginCommandHandler : IRequestHandler<LoginCommand, UserDto>
    {
        private ILoginRepository _loginRepository;
        private IMapper _mapper;
        public LoginCommandHandler(ILoginRepository loginRepository, IMapper mapper)
        {
            _loginRepository = loginRepository;
            _mapper = mapper;
        }

        public async Task<UserDto> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            try
            {
                var response = await _loginRepository.GetUserDetails(request.LoginDto.Email, request.LoginDto.Password);
                if (response == null)
                {
                    return new UserDto();
                }

                var result = _mapper.Map<UserDto>(response);
                return result;
            }
            catch (Exception )
            {
                return null;
            }
        }

        
    }

}
