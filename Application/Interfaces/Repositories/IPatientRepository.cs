using MapProject.Models;
using MapProject.ViewModel.Patient;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Application.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        public Task<IEnumerable<Patient>> GetAsync();
        public Task<Patient> FindAsync(long id);
        public Task<Patient> CreateAsync(Patient entity);
        public void UpdateAsync(Patient entity);
        public void Delete(Patient entity);
        public Task SoftDelete(int id);


    }
}
