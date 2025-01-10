using MapProject.Application.Interfaces.Repositories;
using MapProject.Infrastructure.AppDbContext;
using MapProject.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;

namespace MapProject.Infrastructure.Repositories
{
    public class ChartRepository : IChartRepository
    {
        private readonly ApplicationDbContext _context;
        private static readonly Dictionary<int, string> DistrictMapping = new Dictionary<int, string>
        {
            { 1, "Quận 1" },
            { 2, "Quận 2" },
            { 3, "Quận 3" },
            { 4, "Quận 4" },
            { 5, "Quận 5" },
            { 6, "Quận 7" },
            { 7, "Quận 10" },
            { 8, "Quận Bình Thạnh" },
            { 9, "Quận Phú Nhuận" }
        };
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
                .Where(p => p != null)
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

        public async Task<IEnumerable<object>> GetStatisticsByDistrict()
        {
            var patients = await _context.Patients
                .Where(p => p.Isdelete == false && p.District.HasValue)
                .ToListAsync();

            var data = patients
                .GroupBy(p => p.District.Value)
                .Select(g => new
                {
                    DistrictId = g.Key,
                    Count = g.Count()
                })
                .ToList();

            // Ánh xạ mã quận thành tên quận
            var chartData = data
                .Select(d => new
                {
                    label = DistrictMapping.ContainsKey(d.DistrictId)
                        ? DistrictMapping[d.DistrictId]
                        : $"Quận {d.DistrictId}",
                    y = d.Count
                })
                .ToList();

            return chartData;
        }


    }
}
