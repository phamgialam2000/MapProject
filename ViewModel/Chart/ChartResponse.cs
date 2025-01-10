using MapProject.ViewModel.Patient;
using Microsoft.CodeAnalysis.Elfie.Diagnostics;

namespace MapProject.ViewModel.Chart
{
    public class ChartResponse
    {
        public IEnumerable<object> StatisticsByMonth { get; set; }
        public IEnumerable<object> StatisticsByDistrict { get; set; }
    }
}
