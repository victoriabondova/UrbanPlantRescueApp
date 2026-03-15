using Microsoft.AspNetCore.Mvc;
using UrbanPlantRescueApp.Services.Interfaces;

namespace UrbanPlantRescueApp.Controllers
{
    public class CategoryController : Controller
    {
        private readonly ICategoryService categoryService;
        public CategoryController(ICategoryService categoryService)
        {
            this.categoryService = categoryService;
        }
        public async Task<IActionResult> Index()
        {
            var categories = await categoryService.GetAllCategoriesAsync();
            return View(categories);
        }
    }
}
