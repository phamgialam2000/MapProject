using Microsoft.AspNetCore.Mvc;

namespace MapProject.Controllers
{
    public class ChartController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
