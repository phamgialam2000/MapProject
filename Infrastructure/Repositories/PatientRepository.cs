using MapProject.Application.Interfaces.Repositories;
using MapProject.Data;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Infrastructure.Repositories
{
    public class PatientRepository : IPatientRepository
    {
        private readonly ApplicationDbContext _context;

        public PatientRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<Patient>> GetAllAsync()
        {
            var result = await _context.Patients.ToListAsync();
            return result;
        }

        public async Task<Patient> GetByIdAsync(long id)
        {
            var result = await _context.Patients.FirstOrDefaultAsync(r => r.Id == id);
            return result;
        }

        public Task UpdateAsync(Patient entity)
        {
            throw new NotImplementedException();
        }

        public Task DeleteAsync(long id)
        {
            throw new NotImplementedException();
        }

    }
}
