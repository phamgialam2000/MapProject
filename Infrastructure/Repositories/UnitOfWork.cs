using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.AppDbContext;

namespace MapProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPatientRepository _Patients { get; }
        public UnitOfWork(ApplicationDbContext context, IPatientRepository patient)
        {
            _context = context;
            _Patients = patient;
        }
        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task RollBackAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
