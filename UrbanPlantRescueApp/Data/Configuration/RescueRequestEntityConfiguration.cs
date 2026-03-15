using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using UrbanPlantRescueApp.Models;

namespace UrbanPlantRescueApp.Data.Configuration
{
    public class RescueRequestEntityConfiguration : IEntityTypeConfiguration<RescueRequest>
    {
        public void Configure(EntityTypeBuilder<RescueRequest> entity)
        {
            entity.HasKey(r => r.Id);
            entity.HasOne(r => r.Plant)
                .WithMany(p => p.RescueRequests)
                .HasForeignKey(r => r.PlantId)
                .OnDelete(DeleteBehavior.Restrict);
            entity.HasOne(r => r.Requester)
                .WithMany()
                .HasForeignKey(r => r.RequesterId)
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
