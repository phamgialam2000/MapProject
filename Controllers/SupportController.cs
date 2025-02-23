using Azure.Core;
using MapProject.Application.Interfaces.Services;
using MapProject.Models;
using MapProject.ViewModel.Support;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace MapProject.Controllers
{
    public class SupportController : Controller
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly ISupportService _service;

        //ILogger<HomeController> logger, UserManager<ApplicationUser> userManager,
        public SupportController(IServiceProvider serviceProvider, UserManager<ApplicationUser> userManager)
        {
            this._userManager = userManager;
            _service = serviceProvider.GetRequiredService<ISupportService>();

        }

        public async Task<IActionResult> Index()
        {
           
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(SupportRequest request)
        {
            var result = await _service.CreateAsync(request);

            if (ModelState.IsValid)
            {
                TempData["SuccessMessage"] = "Yêu cầu của bạn đã được gửi thành công.";
                return RedirectToAction("Index");
            }

            return View(request);
        }

        [Authorize]
        public IActionResult List()
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
