namespace UrbanPlantRescueApp.Services.Interfaces
{
    using UrbanPlantRescueApp.ViewModels;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
    }
}
