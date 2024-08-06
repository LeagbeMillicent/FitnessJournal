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
    public class ProfileMapper : Profile
    {
        public ProfileMapper() 
        {
            CreateMap<AddProfileDto, UserProfile>().ReverseMap();
            CreateMap<UpdateProfileDto, UserProfile>().ReverseMap();
            CreateMap<ProfileDto, UserProfile>().ReverseMap();
            CreateMap<userProfile, UserProfile>().ReverseMap();
            CreateMap<RegisterDto, UserProfile>().ReverseMap();
        }
    }
}
