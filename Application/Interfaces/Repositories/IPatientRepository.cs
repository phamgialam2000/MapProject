using MapProject.Models;
using MapProject.ViewModel.Patient;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Application.Interfaces.Repositories
{
    public interface IPatientRepository
    {
        Task<IEnumerable<Patient>> GetAsync();
        Task<Patient> FindAsync(long id);
        Task<Patient> CreateAsync(Patient entity);
        Task UpdateAsync(Patient entity);
        Task DeleteAsync(Patient entity);
        Task<bool> SoftDeleteAsync(int id);
        Task<(List<PatientResponse>, int)> Search(PatientRequest request);


    }
}
