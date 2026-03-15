using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPlantRescueApp.Common;
using UrbanPlantRescueApp.Models;
namespace UrbanPlantRescueApp.Data.Configuration
{
    public class PlantEntityConfiguration  : IEntityTypeConfiguration<Plant>
    {
        private readonly IEnumerable<Plant> Plants = new List<Plant>
        {
            new Plant { Id = 1, Name = "Монстера", Description = "Иконично стайно растение с големи листа.", CategoryId = 1 },
            new Plant { Id = 2, Name = "Лавандула", Description = "Ароматна и лечебна, обича слънце.", CategoryId = 5 },
            new Plant { Id = 3, Name = "Ечеверия", Description = "Красив сукулент с формата на роза.", CategoryId = 3 },
            new Plant { Id = 4, Name = "Хортензия", Description = "Обилно цъфтящ храст с големи съцветия.", CategoryId = 2 },
            new Plant { Id = 5, Name = "Орхидея", Description = "Елегантно цвете с изящни цветове.", CategoryId = 4 },
            new Plant { Id = 6, Name = "Розмарин", Description = "Ароматна подправка, подходяща за саксия.", CategoryId = 5 },
            new Plant { Id = 7, Name = "Алое Вера", Description = "Лековито растение, лесно за отглеждане.", CategoryId = 3 }
        };
        public void Configure(EntityTypeBuilder<Plant> entity)
        {
            entity.HasKey(p => p.Id);
            entity.Property(p => p.Name)
                .IsRequired()
                .HasMaxLength(DataValidation.Plant.NameMaxLength);
            entity.Property(p => p.Description)
                .IsRequired()
                .HasMaxLength(DataValidation.Plant.DescriptionMaxLength);
            entity.HasOne(p => p.Category)
                .WithMany(c => c.Plants)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(p => p.Owner)
                .WithMany()
                .HasForeignKey(p => p.OwnerId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasData(Plants);
        }
    }
}
