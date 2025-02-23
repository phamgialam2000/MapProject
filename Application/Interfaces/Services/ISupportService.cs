using MapProject.Models;

namespace MapProject.Application.Interfaces.Services
{
    public interface ISupportService
    {
        public Task<IEnumerable<Support>> GetAsync();
        public Task<Support> FindAsync(long id);
        public Task<Support> CreateAsync(Support entity);
        public Task<Support> UpdateAsync(Support entity);
        public Task<bool> DeleteAsync(Support entity);
    }
}
