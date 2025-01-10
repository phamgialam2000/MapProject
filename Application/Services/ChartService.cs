using MapProject.Application.Interfaces.Services;
using MapProject.Application.Interfaces;
using MapProject.Models;

namespace MapProject.Application.Services
{
    public class ChartService : IChartService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger<ChartService> _logger;

        public ChartService(IUnitOfWork unitOfWork, ILogger<ChartService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<IEnumerable<object>> GetStatisticsAsync()
        {
            try
            {
                return await _unitOfWork._charts.GetStatistics();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when GetStatistics {ex}", ex.Message);
                throw;
            }
        }

        public async Task<IEnumerable<object>> GetStatisticsByDistrictAsync()
        {
            try
            {
                return await _unitOfWork._charts.GetStatisticsByDistrict();
            }
            catch (Exception ex)
            {
                _logger.LogError($"Error when GetStatisticsByDistrictAsync {ex}", ex.Message);
                throw;
            }
        }
    }
}
