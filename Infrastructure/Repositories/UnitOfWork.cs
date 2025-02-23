using MapProject.Application.Interfaces;
using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;

namespace MapProject.Infrastructure.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ApplicationDbContext _context;
        public IPatientRepository _patients { get; }
        public IChartRepository _charts { get; }
        public ISupportRepository _support { get; }

        public ISupportRepository _supports => throw new NotImplementedException();

        public UnitOfWork(ApplicationDbContext context, IPatientRepository patient, IChartRepository chart, ISupportRepository support)
        {
            _context = context;
            _patients = patient;
            _charts = chart;
            _support = support;
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
