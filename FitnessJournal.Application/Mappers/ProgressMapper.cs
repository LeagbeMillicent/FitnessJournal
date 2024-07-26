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
    public class ProgressMapper : Profile
    {
        public ProgressMapper() 
        { 
            CreateMap<AddProgressDto, Progress>().ReverseMap();
            CreateMap<UpdateProgressDto, Progress>().ReverseMap();
            CreateMap<ProgressDto, Progress>().ReverseMap();

        }
    }
}
