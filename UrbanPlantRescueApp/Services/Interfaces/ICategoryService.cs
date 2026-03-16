namespace UrbanPlantRescueApp.Services.Interfaces
{
    using UrbanPlantRescueApp.ViewModels;
    public interface ICategoryService
    {
        Task<IEnumerable<CategoryViewModel>> GetAllCategoriesAsync();
        Task AddCategoryAsync(CategoryFormViewModel model);
        Task<bool> CategoryExistsAsync(string name);
    }
}
