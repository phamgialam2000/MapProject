using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;

namespace MapProject.Infrastructure.Repositories
{
    public class ChartRepository: IChartRepository
    {
        private readonly ApplicationDbContext _context;

        public ChartRepository(ApplicationDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<object>> GetStatistics()
        {
            var patients = await _context.Patients
                .Where(p => p.Isdelete == false && !string.IsNullOrEmpty(p.Date))
                .ToListAsync();

            var data = patients
                .Select(p =>
                {
                    if (DateTime.TryParse(p.Date, out var parsedDate))
                    {
                        return new
                        {
                            p.Level,
                            DateParsed = parsedDate
                        };
                    }
                    return null;
                })
                .Where(p => p != null) // Lọc bỏ các giá trị null
                .GroupBy(p => new { p.Level, Month = p.DateParsed.Month, Year = p.DateParsed.Year })
                .Select(g => new
                {
                    Level = g.Key.Level,
                    Date = new DateTime(g.Key.Year, g.Key.Month, 1),
                    Count = g.Count()
                })
                .OrderBy(d => d.Date)
                .ToList();

            // Chuyển đổi dữ liệu thành JSON
            var chartData = data
                .GroupBy(d => d.Level)
                .Select(g => new
                {
                    name = g.Key,
                    dataPoints = g.Select(d => new
                    {
                        x = d.Date,
                        y = d.Count
                    }).ToList()
                }).ToList();

            return chartData;
        }
       
    }
}
