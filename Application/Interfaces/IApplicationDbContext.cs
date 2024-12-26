using MapProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Application.Interfaces
{
    public interface IApplicationDbContext : IDbContext
    {
        public DbSet<Patient> Patients { get;}
    }
    
}
