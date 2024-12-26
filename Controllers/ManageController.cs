using MapProject.Application.Interfaces.Services;
using MapProject.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MapProject.Controllers
{
    [Authorize]
    public class ManageController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IPatientService _service;

        //ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
        public ManageController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            _service = serviceProvider.GetRequiredService<IPatientService>();
        }

        public async Task<IActionResult> Index()
        {
            ViewData["UserID"] = _userManager.GetUserId(this.User);
            var result = await _service.GetAsync();
            return View(result);
        }
        public async Task<IActionResult> Add()
        {
            var result = await _service.GetAsync();
            return View(result);
        }
        public async Task<IActionResult> Edit(long id)
        {
            var result = await _service.GetById(id);
            return View(result);
        }
        public async Task<IActionResult> Delete()
        {
            var result = await _service.GetAsync();
            return View(result);
        }
       
        
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}