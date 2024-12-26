using MapProject.Application.Interfaces.Services;
using MapProject.Application.Interfaces;
using MapProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Application.Services
{
    public class PatientService : IPatientService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<PatientService> _logger;

        public PatientService(IUnitOfWork unitOfWork, ILogger<PatientService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<Patient>> GetAsync()
        {
            try
            {
                return await _unitOfWork._Patients.GetAllAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when GetAsync {ex}", ex.Message);
                throw;
            }

        }
       
    }
}