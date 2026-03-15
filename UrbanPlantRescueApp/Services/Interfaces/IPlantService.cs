namespace UrbanPlantRescueApp.Services.Interfaces
{
    using UrbanPlantRescueApp.ViewModels;
    public interface IPlantService
    {
        Task<IEnumerable<PlantViewModel>> GetAllPlantsAsync();
        Task<PlantViewModel?> GetPlantByIdAsync(int id);
    }
}
