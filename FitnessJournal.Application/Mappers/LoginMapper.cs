using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Mappers
{
    public class LoginMapper : Profile
    {
        public LoginMapper()
        {
            CreateMap<LoginDto, Login>().ReverseMap(); 
            CreateMap<userProfile, UserProfile>().ReverseMap(); 
        }
    }
}
