using MapProject.Application.Interfaces.Services;
using MapProject.Application.Interfaces;
using MapProject.Models;
using Microsoft.EntityFrameworkCore;
using MapProject.ViewModel.Patient;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.Blazor;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Net;
using System.Text.RegularExpressions;

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

        public async Task<Patient> CreateAsync(PatientRequest request)
        {
            try
            {
                var patient = new Patient()
                {
                    Latitude = request.Latitude,
                    Longitude = request.Longitude,
                    Name = request.Name,
                    Address = request.Address,
                    Phone = request.Phone,
                    Type = request.Type,
                    Level = request.Level,
                    Group = request.Group,
                    Note = request.Note,
                    Date = request.Date,
                    District = request.District,
                    Dateofbirth = request.Dateofbirth,
                    Isdelete = false,
                };
                var result = await _unitOfWork._patients.CreateAsync(patient);
                await _unitOfWork.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when Create {ex}", ex.Message);
                throw;
            }

        }

        public async Task<bool> SoftDelete(int id)
        {
            try
            {
                await _unitOfWork._patients.SoftDeleteAsync(id);
                await _unitOfWork.CommitAsync();
                return true;
            }
            catch (Exception ex)
            {
                await _unitOfWork.RollBackAsync();
                _logger.LogError($"Error when Delete {ex}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<Patient>> GetAsync()
        {
            try
            {
                return await _unitOfWork._patients.GetAsync();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when GetAllAsync {ex}", ex.Message);
                throw;
            }

        }

        public async Task<Patient> FindAsync(long id)
        {
            try
            {
                return await _unitOfWork._patients.FindAsync(id);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when GetAsync {ex}", ex.Message);
                throw;
            }
        }

       
        public async Task<(List<PatientResponse>, int)> GetSearchPagingAsync(PatientRequest request)
        {
            return await _unitOfWork._patients.Search(request);
        }

        public async Task<Patient> UpdateAsync(PatientRequest request)
        {
            try
            {
                var result = await FindAsync(request.Id);
                result.Latitude = request.Latitude;
                result.Longitude = request.Longitude;
                result.Name = request.Name;
                result.Address = request.Address;
                result.Phone = request.Phone;
                result.Type = request.Type;
                result.Level = request.Level;
                result.Group = request.Group;
                result.Note = request.Note;
                result.Date = request.Date;
                result.District = request.District;
                result.Dateofbirth = request.Dateofbirth;
                result.Isdelete = false;

                await _unitOfWork._patients.UpdateAsync(result);
                await _unitOfWork.CommitAsync();
                return result;
            }
            catch (Exception ex)
            {
                 await _unitOfWork.RollBackAsync();
                _logger.LogError($"Error Update {ex}", ex.Message);
                throw;
            }
        }
    }
}