using Microsoft.AspNetCore.Mvc;
using UrbanPlantRescueApp.Services.Interfaces;

namespace UrbanPlantRescueApp.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantService plantService;

        public PlantController(IPlantService plantService)
        {
            this.plantService = plantService;
        }
        public async Task<IActionResult> Index()
        {
            var plants = await plantService.GetAllPlantsAsync();
            return View(plants);
        }
        public async Task<IActionResult> Details(int id)
        {
            var plant = await plantService.GetPlantByIdAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            return View(plant);
        }
    }
}
