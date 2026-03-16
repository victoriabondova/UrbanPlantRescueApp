using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using UrbanPlantRescueApp.Data;
using UrbanPlantRescueApp.Services;
using UrbanPlantRescueApp.Services.Interfaces;
using UrbanPlantRescueApp.ViewModels;

namespace UrbanPlantRescueApp.Controllers
{
    [Authorize]
    public class PlantController : Controller
    {
        private readonly ApplicationDbContext dbContext;
        private readonly IPlantService plantService;
        private readonly ICategoryService categoryService;
        public PlantController(ApplicationDbContext dbContext, IPlantService plantService, ICategoryService categoryService)
        {
            this.dbContext = dbContext;
            this.plantService = plantService;
            this.categoryService = categoryService;
        }
        [AllowAnonymous]
        public async Task<IActionResult> Index()
        {
            var allPlants = await plantService.GetAllPlantsAsync();
            return View(allPlants);
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
            var plant = await dbContext.Plants.FindAsync(id);
            if (plant == null) { return NotFound(); }
            if (!ModelState.IsValid)
            {
                model.Categories = await categoryService.GetAllCategoriesAsync();
                return View(model);
            }
            await plantService.EditPlantAsync(id, model);
            return RedirectToAction(nameof(Index));
        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id)
        {
            var plant = await plantService.GetPlantByIdAsync(id);
            if (plant == null) return NotFound();
            return View(plant);
        }
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var plant = await dbContext.Plants.FindAsync(id);
            if (plant == null)
            {
                return NotFound();
            }
            await plantService.DeletePlantAsync(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
