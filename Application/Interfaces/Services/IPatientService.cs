using MapProject.Models;
using MapProject.ViewModel.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace MapProject.Application.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAsync();
        Task<Patient> FindAsync(long id);
        Task<Patient> CreateAsync(PatientRequest request);
        Task<Patient> UpdateAsync(PatientRequest request);
        Task<bool> SoftDelete(int id);
        Task<(List<PatientResponse>, int)> GetSearchPagingAsync(PatientRequest request);


    }
}
