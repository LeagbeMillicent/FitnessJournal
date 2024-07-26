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
    public class GoalMapper : Profile
    {
        public GoalMapper()
        {
            CreateMap<AddGoalDto, Goal>().ReverseMap();
            CreateMap<UpdateGoalDto, Goal>().ReverseMap();
            CreateMap<GoalDto, Goal>().ReverseMap();
        }
    }
}
