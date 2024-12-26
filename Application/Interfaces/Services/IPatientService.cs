using MapProject.Models;
using Microsoft.AspNetCore.Identity;

namespace MapProject.Application.Interfaces.Services
{
    public interface IPatientService
    {
        Task<IEnumerable<Patient>> GetAsync();

    }
}
