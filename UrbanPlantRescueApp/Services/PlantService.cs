namespace UrbanPlantRescueApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using UrbanPlantRescueApp.Data;
    using UrbanPlantRescueApp.ViewModels;
    using UrbanPlantRescueApp.Services.Interfaces;
    public class PlantService : IPlantService
    {
        private readonly ApplicationDbContext dbContext;
        public PlantService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<IEnumerable<PlantViewModel>> GetAllPlantsAsync()
        {
            return await dbContext.Plants
                .Include(p => p.Category)
                .Select(p => new PlantViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CategoryName = p.Category.Name
                })
                .ToListAsync();
        }
        public async Task<PlantViewModel?> GetPlantByIdAsync(int id)
        {
            return await dbContext.Plants
                .Include(p => p.Category)
                .Where(p => p.Id == id)
                .Select(p => new PlantViewModel
                {
                    Id = p.Id,
                    Name = p.Name,
                    Description = p.Description,
                    CategoryName = p.Category.Name
                })
                .FirstOrDefaultAsync();
        }
    }
}
