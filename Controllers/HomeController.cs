using MapProject.Application.Interfaces.Services;
using MapProject.Application.Services;
using MapProject.Areas.Identity.Data;
using MapProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.DependencyInjection;
using System.Diagnostics;

namespace MapProject.Controllers
{

    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientService _service;

        //ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
        public HomeController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            _service = serviceProvider.GetRequiredService<IPatientService>();

        }

        public async Task<IActionResult> Index()
        {
            var result = await _service.GetAsync();
            return View(result);
        }


        [Authorize]
        public IActionResult Privacy()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}