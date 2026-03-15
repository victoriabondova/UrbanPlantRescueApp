namespace UrbanPlantRescueApp.ViewModels
{
    using System.ComponentModel.DataAnnotations;
    using UrbanPlantRescueApp.Common;
    public class PlantFormViewModel
    {
        [Required]
        [MaxLength(DataValidation.Plant.NameMaxLength)]
        public string Name { get; set; } = null!;
        [Required]
        [MaxLength(DataValidation.Plant.DescriptionMaxLength)]
        public string Description { get; set; } = null!;
        [Required]
        [Display(Name = "Категория")]
        public int CategoryId { get; set; }
        public IEnumerable<CategoryViewModel> Categories { get; set; } = new List<CategoryViewModel>();
    }
}
