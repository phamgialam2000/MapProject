using Azure.Core;
using MapProject.Application.Interfaces.Services;
using MapProject.Models;
using MapProject.ViewModel.Patient;
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
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Add(PatientRequest request)
        {
            try
            {
                var result = await _service.Create(request);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Thêm mới thành công!";
                    return RedirectToAction("Index");

                }
                ModelState.AddModelError("", "Thêm mới thất bại.");
                return View(request);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi trong quá trình xử lý.");
                return View(request);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Edit(long id)
        {
            var result = await _service.FindAsync(id);
            return View(result);
        }
        [HttpPost]
        public async Task<IActionResult> Edit(PatientRequest request)
        {
            try
            {
                var result = await _service.Update(request);
                if (result != null)
                {
                    TempData["SuccessMessage"] = "Cập nhật thành công!";
                    return RedirectToAction("Edit", new { id = request.Id });

                }
                ModelState.AddModelError("", "Cập nhật thất bại.");
                return View(request);
            }
            catch (Exception)
            {
                ModelState.AddModelError("", "Đã xảy ra lỗi trong quá trình xử lý.");
                return View(request);
            }
        }

        public async Task<IActionResult> Delete(PatientRequest request)
        {
            var res = await _service.SoftDelete(request.Id);
            return RedirectToAction("Index");

        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}