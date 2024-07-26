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
    public class FitnessMapper : Profile
    {
        public FitnessMapper() {
            CreateMap<AddFitnessInfoDto, FitnessInformation>().ReverseMap();
            CreateMap<UpdateFitnessInfoDto, FitnessInformation>().ReverseMap();
            CreateMap<FitnessInfoDto, FitnessInformation>().ReverseMap();

        }

    }
}
