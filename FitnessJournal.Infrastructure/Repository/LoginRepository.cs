using AutoMapper;
using FitnessJournal.Application.Dto;
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using FitnessJournal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly FitnessJournalContext _context;
        public LoginRepository(FitnessJournalContext fitnessContext)
        {
            _context = fitnessContext;
        }
        public async Task<UserProfile> GetUserDetails(string? username, string? password)
        {
            return await _context.Profiles.Where(x => x.Name == username && x.Password == password).FirstOrDefaultAsync();
        }
    }
}
