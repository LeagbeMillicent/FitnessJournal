
using FitnessJournal.Application.Repository;
using FitnessJournal.Domain;
using FitnessJournal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;


namespace FitnessJournal.Infrastructure.Repository
{
    public class LoginRepository : ILoginRepository
    {
        private readonly FitnessJournalContext _context;
        public LoginRepository(FitnessJournalContext fitnessContext)
        {
            _context = fitnessContext;
        }
        public async Task<UserProfile> GetUserDetails(string? email, string? password)
        {
            return await _context.Profiles.Where(x => x.Email == email && x.Password == password).FirstOrDefaultAsync();
        }
    }
}
