using FitnessJournal.Application.Repository;
using FitnessJournal.Infrastructure.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FitnessJournal.Infrastructure.Repository
{
    public class FitnessRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly FitnessJournalContext _context;

        public FitnessRepository(FitnessJournalContext context)
        {
            _context = context;
        }

        public async Task<T> AddAsync(T entity)
        {
            await _context.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> DeleteAsync(T Id)
        {
            var entity = _context.Set<T>().FindAsync(Id);
            if(entity != null)
            {
                return false;
            }

            _context.Set<T>().Remove(Id);
            await _context.SaveChangesAsync();
            return true;

        }

        public async Task<IReadOnlyList<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> GetByIdAsync(int id)
        {
            return await _context.Set<T>().FindAsync(id);
        }

        public async Task<T> UpdateAsync(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }
    }
}
