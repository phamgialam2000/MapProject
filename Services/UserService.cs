using MapProject.Models;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Services
{
    public class UserService
    {
        private readonly DbContext _context;

        public UserService(DbContext context)
        {
            _context = context;
        }

        public async Task<List<Patient>> GetAllLocationsAsync()
        {
            return await _context.Set<Patient>().ToListAsync();
        }
    }
}