using Azure.Core;
using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Services;
using MapProject.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.BlazorIdentity.Pages.Manage;

namespace MapProject.Application.Services
{
    public class SupportService : ISupportService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<SupportService> _logger;

        public SupportService(IUnitOfWork unitOfWork, ILogger<SupportService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<Support> CreateAsync(Support request)
        {
            {
                try
                {
                    var support = new Support()
                    {
                        Sid = request.Sid,
                        Sname = request.Sname,
                        Sphone = request.Sphone,
                        Semail = request.Semail,
                        Scontent = request.Scontent,
                        IsScomplete = request.IsScomplete ?? false

                    };
                    var result = await _unitOfWork._supports.CreateAsync(support);
                    await _unitOfWork.CommitAsync();
                    return result;
                }
                catch (Exception ex)
                {
                    _logger.LogError($"Error when Create {ex}", ex.Message);
                    throw;
                }

            }
        }

        public async Task<bool> DeleteAsync(Support entity)
        {
            try
            {
                await _unitOfWork._supports.DeleteAsync(entity);
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

        public Task<Support> FindAsync(long id)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Support>> GetAsync()
        {
            throw new NotImplementedException();
        }

        public Task<Support> UpdateAsync(Support entity)
        {
            throw new NotImplementedException();
        }
    }
}
