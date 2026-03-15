namespace UrbanPlantRescueApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using UrbanPlantRescueApp.Data;
    using UrbanPlantRescueApp.ViewModels;
    using UrbanPlantRescueApp.Services.Interfaces;
    public class CategoryService : ICategoryService
    {
        private readonly ApplicationDbContext dbContext;
        public CategoryService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync()
        {
            return await dbContext.Categories
                .Select(c => new CategoryViewModel
                {
                    Id = c.Id,
                    Name = c.Name
                }).ToListAsync();
        }
    }
}
