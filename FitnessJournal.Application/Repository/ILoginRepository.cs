using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Application.Repository
{
    public interface ILoginRepository 
    {
        Task<UserProfile> GetUserDetails (string username, string password);
    }
}
