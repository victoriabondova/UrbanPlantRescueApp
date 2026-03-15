using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using UrbanPlantRescueApp.Models;
using UrbanPlantRescueApp.Common;

namespace UrbanPlantRescueApp.Data.Configuration
{
    public class CategoryEntityConfiguration : IEntityTypeConfiguration<Category>
    {
        private readonly IEnumerable<Category> Categories = new List<Category>
        {
            new Category { Id = 1, Name = "Стайни растения" },
            new Category { Id = 2, Name = "Градински цветя" },
            new Category { Id = 3, Name = "Сукуленти и кактуси" },
            new Category { Id = 4, Name = "Цъфтящи растения" },
            new Category { Id = 5, Name = "Билки и подправки" }
        };

        public void Configure(EntityTypeBuilder<Category> entity)
        {
            entity.HasKey(c => c.Id);
            entity.Property(c => c.Name)
                .IsRequired()
                .HasMaxLength(DataValidation.Category.CategoryNameMaxLength);
            entity.HasData(Categories);
        }
    }
}
