using MapProject.Application.Interfaces.Repositories;
using MapProject.Application.Interfaces.Services;

namespace MapProject.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IPatientRepository _patients { get; }
        IChartRepository _charts { get; }
        Task CommitAsync();
        Task RollBackAsync();
    }
}
