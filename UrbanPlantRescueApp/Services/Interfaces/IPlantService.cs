namespace UrbanPlantRescueApp.Services.Interfaces
{
    using UrbanPlantRescueApp.ViewModels;
    public interface IPlantService
    {
        Task<IEnumerable<PlantViewModel>> GetAllPlantsAsync();
        Task<PlantViewModel?> GetPlantByIdAsync(int id);
        Task AddPlantAsync(PlantFormViewModel model);
        Task<PlantFormViewModel?> GetPlantForEditAsync(int id);
        Task EditPlantAsync(int id, PlantFormViewModel model);
        Task DeletePlantAsync(int id);
    }
}
