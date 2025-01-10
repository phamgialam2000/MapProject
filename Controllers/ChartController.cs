using MapProject.Application.Interfaces.Services;
using MapProject.Models;
using MapProject.ViewModel.Chart;
using MapProject.ViewModel.Patient;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace MapProject.Controllers
{
    public class ChartController : Controller
    {
        private readonly IChartService _service;

        public ChartController(IServiceProvider serviceProvider)
        {
            _service = serviceProvider.GetRequiredService<IChartService>();
        }

        public async Task<IActionResult> Index()
        {
            var resByMonth = await _service.GetStatisticsAsync();
            var resByDistric = await _service.GetStatisticsByDistrictAsync();
            var viewModel = new ChartResponse
            {
                StatisticsByMonth = resByMonth,
                StatisticsByDistrict = resByDistric
            };

            return View(viewModel);
        }
    }
}
