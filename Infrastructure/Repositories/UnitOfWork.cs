using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.AppDbContext;

namespace MapProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPatientRepository _patients { get; }
        public IChartRepository _charts { get; }
        public UnitOfWork(ApplicationDbContext context, IPatientRepository patient, IChartRepository chart)
        {
            _context = context;
            _patients = patient;
            _charts = chart;
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
