using MapProject.Models;

namespace MapProject.Application.Interfaces.Repositories
{
    public interface ISupportRepository
    {
         Task<IEnumerable<Support>> GetAsync();
         Task<Support> FindAsync(long id);
         Task<Support> CreateAsync(Support entity);
         Task UpdateAsync(Support entity);
         Task DeleteAsync(Support entity);

    }
}
