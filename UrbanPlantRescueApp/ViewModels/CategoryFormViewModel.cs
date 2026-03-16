using UrbanPlantRescueApp.Common;
using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;

namespace UrbanPlantRescueApp.ViewModels
{
    public class CategoryFormViewModel
    {
        [Required]
        [UniqueCategory]
        public string Name { get; set; } = null!;
    }
}
