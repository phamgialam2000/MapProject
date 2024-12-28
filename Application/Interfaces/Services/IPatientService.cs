using MapProject.Models;
using MapProject.ViewModel.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace MapProject.Application.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetSearchPagingAsync();
        Task<IEnumerable<Patient>> GetAsync();
        Task<Patient> FindAsync(long id);
        Task<Patient> Create(PatientRequest request);
        Task<Patient> Update(PatientRequest request);
        Task<bool> SoftDelete(int id);

    }
}
