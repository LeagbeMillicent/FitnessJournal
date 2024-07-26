﻿using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Mappers
{
    public class WorkoutMapper : Profile
    {
        public WorkoutMapper() 
        { 
            CreateMap<AddWorkoutDto, Workout>().ReverseMap();
            CreateMap<UpdateWorkoutDto, Workout>().ReverseMap();
            CreateMap<WorkoutDto, Workout>().ReverseMap();
        }  
    }
}
