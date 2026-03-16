using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UrbanPlantRescueApp.Services.Interfaces;

namespace UrbanPlantRescueApp.Controllers
{
    [Authorize]
    public class RescueRequestController : Controller
    {
        private readonly IRescueRequestService rescueRequestService;
        public RescueRequestController(IRescueRequestService rescueRequestService)
        {
            this.rescueRequestService = rescueRequestService;
        }
        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(int plantId)
        {
            string userId = User.FindFirstValue(ClaimTypes.NameIdentifier)!;
            await rescueRequestService.CreateRescueRequestAsync(plantId, userId);
            TempData["Success"] = "Заявката за спасяване беше изпратена успешно!";
            return RedirectToAction("Details", "Plant", new { id = plantId });
        }
    }
}
