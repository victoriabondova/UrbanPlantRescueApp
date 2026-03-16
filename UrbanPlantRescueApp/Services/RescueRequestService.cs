namespace UrbanPlantRescueApp.Services
{
    using UrbanPlantRescueApp.Data;
    using UrbanPlantRescueApp.Models;
    using UrbanPlantRescueApp.Services.Interfaces;
    public class RescueRequestService : IRescueRequestService
    {
        private readonly ApplicationDbContext dbContext;
        public RescueRequestService(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task CreateRescueRequestAsync(int plantId, string requesterId)
        {
            var request = new RescueRequest
            {
                PlantId = plantId,
                RequesterId = requesterId,
                RequestedOn = DateTime.Now,
                IsApproved = "Pending"
            };
            await dbContext.RescueRequests.AddAsync(request);
            await dbContext.SaveChangesAsync();
        }
    }
}
