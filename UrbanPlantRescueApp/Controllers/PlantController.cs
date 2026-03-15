using Microsoft.AspNetCore.Mvc;
using UrbanPlantRescueApp.Services;
using UrbanPlantRescueApp.Services.Interfaces;
using UrbanPlantRescueApp.ViewModels;

namespace UrbanPlantRescueApp.Controllers
{
    public class PlantController : Controller
    {
        private readonly IPlantService plantService;
        private readonly ICategoryService categoryService;
        public PlantController(IPlantService plantService, ICategoryService categoryService)
        {
            this.plantService = plantService;
            this.categoryService = categoryService;
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
        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            var model = new PlantFormViewModel
            {
                Categories = categories
            };
            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Create(PlantFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategoriesAsync();
                return View(model);
            }
            await plantService.AddPlantAsync(model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            var model = await plantService.GetPlantForEditAsync(id);

            if (model == null) return NotFound();

            model.Categories = await categoryService.GetAllCategoriesAsync();
            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(int id, PlantFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategoriesAsync();
                return View(model);
            }

            await plantService.EditPlantAsync(id, model);
            return RedirectToAction(nameof(Index));
        }
    }
}
