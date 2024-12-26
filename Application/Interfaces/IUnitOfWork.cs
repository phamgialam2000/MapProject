using MapProject.Application.Interfaces.Repositories;
using MapProject.Application.Interfaces.Services;

namespace MapProject.Application.Interfaces
{
    public interface IUnitOfWork
    {
        IPatientRepository _Patients { get; }
    }
}
