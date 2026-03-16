using System.ComponentModel.DataAnnotations;
using UrbanPlantRescueApp.Services.Interfaces;

namespace UrbanPlantRescueApp.Common
{
    public class UniqueCategoryAttribute : ValidationAttribute
    {
        protected override ValidationResult? IsValid(object? value, ValidationContext validationContext)
        {
            var service = validationContext.GetService<ICategoryService>();
            var name = value?.ToString();

            if (name != null && service!.CategoryExistsAsync(name).Result)
            {
                return new ValidationResult("Тази категория вече съществува!");
            }

            return ValidationResult.Success;
        }
    }
}
