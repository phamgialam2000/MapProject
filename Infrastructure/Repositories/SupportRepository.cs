using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Infrastructure.Repositories
{
    public class SupportRepository : ISupportRepository
    {
        private readonly ApplicationDbContext _context;

        public SupportRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Support>> GetAsync()
        {
            var result = await _context.Support.ToListAsync();
            return result;
        }
        public async Task<Support> FindAsync(long id)
        {
            var result = await _context.Support.AsNoTracking().FirstOrDefaultAsync(r => r.Sid == id);
            return result;
        }

        public async Task<Support> CreateAsync(Support entity)
        {
            await _context.Support.AddAsync(entity);
            return entity;
        }

        public Task DeleteAsync(Support entity)
        {
            _context.Support.Remove(entity);
            return Task.CompletedTask;

        }

        public Task UpdateAsync(Support entity)
        {
            _context.Support.Update(entity);
            return Task.CompletedTask;

        }
    }
}
