using MapProject.Models;

namespace MapProject.Application.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        
        public Task<IEnumerable<Patient>> GetAllAsync();
        public Task<Patient> GetByIdAsync(long id);
        public Task UpdateAsync(Patient entity);
        public Task DeleteAsync(long id);
    }
}
