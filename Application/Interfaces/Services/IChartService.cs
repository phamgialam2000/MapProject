using MapProject.Models;

namespace MapProject.Application.Interfaces.Services
{
    public interface IChartService
    {
        Task<IEnumerable<object>> GetStatisticsAsync();
        Task<IEnumerable<object>> GetStatisticsByDistrictAsync();

    }
}
