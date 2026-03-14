using System.ComponentModel.DataAnnotations;
using static UrbanPlantRescueApp.Common.DataValidation.Category;

namespace UrbanPlantRescueApp.Models
{
    public class Category
    {
        [Key]
        public int Id { get; set; }
        [Required]
        [MaxLength(CategoryNameMaxLength)]
        public string Name { get; set; } = null!;
    }
}
