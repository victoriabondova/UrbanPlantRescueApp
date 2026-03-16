namespace UrbanPlantRescueApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using UrbanPlantRescueApp.Data;
    using UrbanPlantRescueApp.ViewModels;
    using UrbanPlantRescueApp.Services.Interfaces;
    using UrbanPlantRescueApp.Models;

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
                    CategoryName = p.Category.Name,
                    ImageUrl = p.ImageUrl
                })
                .FirstOrDefaultAsync();
        }
        public async Task AddPlantAsync(PlantFormViewModel model)
        {
            var plant = new Plant
            {
                Name = model.Name,
                Description = model.Description,
                CategoryId = model.CategoryId,
                ImageUrl = model.ImageUrl
            };
            await dbContext.Plants.AddAsync(plant);
            await dbContext.SaveChangesAsync();
        }
        public async Task<PlantFormViewModel?> GetPlantForEditAsync(int id)
        {
            var plant = await dbContext.Plants.FindAsync(id);
            if (plant == null) return null;
            return new PlantFormViewModel
            {
                Name = plant.Name,
                Description = plant.Description,
                CategoryId = plant.CategoryId
            };
        }
        public async Task EditPlantAsync(int id, PlantFormViewModel model)
        {
            var plant = await dbContext.Plants.FindAsync(id);
            if (plant != null)
            {
                plant.Name = model.Name;
                plant.Description = model.Description;
                plant.CategoryId = model.CategoryId;
                plant.ImageUrl = model.ImageUrl;
                await dbContext.SaveChangesAsync();
            }
        }
        public async Task DeletePlantAsync(int id)
        {
            var relatedRequests = dbContext.RescueRequests.Where(r => r.PlantId == id);
            dbContext.RescueRequests.RemoveRange(relatedRequests);
            var plant = await dbContext.Plants.FindAsync(id);
            if (plant != null)
            {
                dbContext.Plants.Remove(plant);
                await dbContext.SaveChangesAsync();
            }
        }
    }
}
