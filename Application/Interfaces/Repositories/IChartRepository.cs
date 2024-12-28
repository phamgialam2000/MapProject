using MapProject.Models;

namespace MapProject.Application.Interfaces.Repositories
{
    public interface IChartRepository
    {
        public Task<IEnumerable<object>> GetStatistics();

    }
}
