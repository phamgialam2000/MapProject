using Azure.Core;
using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Repositories;
using MapProject.Data;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;
using MapProject.ViewModel.Patient;
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
        public async Task<IEnumerable<Patient>> GetAsync()
        {
            var result = await _context.Patients.Where(x=>x.Isdelete == false).ToListAsync();
            return result;
        }

        public async Task<Patient> FindAsync(long id)
        {
            var result = await _context.Patients.AsNoTracking().FirstOrDefaultAsync(r => r.Id == id);
            return result ?? throw new NotImplementedException();
        }

        public async Task<Patient> CreateAsync(Patient entity)
        {
            await _context.Patients.AddAsync(entity);
            return entity;

        }
        public void UpdateAsync(Patient entity)
        {
            _context.Patients.Update(entity);
        }

        public void Delete(Patient entity)
        {
            _context.Patients.Remove(entity);   
        }

        public async Task SoftDelete(int id)
        {
            var entity = await _context.Patients.FindAsync(id);
            if (entity == null) throw new KeyNotFoundException("Patient not found.");

            entity.Isdelete = true;

            _context.Patients.Update(entity);
        }
    }
}
