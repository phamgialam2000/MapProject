using MapProject.Areas.Identity.Data;
using MapProject.Models;
using MapProject.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MapProject.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly UserService _userService;
       
        public HomeController(ILogger<HomeController> logger, UserService userService, UserManager<ApplicationUser> userManager)
        {
            _logger = logger;
            this._userManager = userManager;
            _userService = userService;
        }
        
        public async Task<IActionResult> Index()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            var locations = await _userService.GetAllLocationsAsync();
            return View();
        }

        
        [Authorize]
        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}