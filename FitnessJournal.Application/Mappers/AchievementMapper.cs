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
    public class AchievementMapper : Profile
    {
        public AchievementMapper() 
        { 
            CreateMap<AddAchievementDto, Achievement>().ReverseMap();
            CreateMap<UpdateAchievementDto, Achievement>().ReverseMap();
            CreateMap<AchievementDto, Achievement>().ReverseMap();
        }

    }
}
