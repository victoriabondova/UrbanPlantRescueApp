namespace UrbanPlantRescueApp.Services
{
    using Microsoft.EntityFrameworkCore;
    using UrbanPlantRescueApp.Data;
    using UrbanPlantRescueApp.Models;
    using UrbanPlantRescueApp.Services.Interfaces;
    using UrbanPlantRescueApp.ViewModels;

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
        public async Task<IEnumerable<RescueRequestViewModel>> GetRequestsByPlantIdAsync(int plantId)
        {
            return await dbContext.RescueRequests
                .Where(r => r.PlantId == plantId)
                .Include(r => r.Requester)
                .Select(r => new RescueRequestViewModel
                {
                    PlantName = r.Plant.Name,
                    RequesterEmail = r.Requester.Email,
                    RequestDate = r.RequestedOn,
                    Status = r.IsApproved
                })
                .ToListAsync();
        }
    }
}
