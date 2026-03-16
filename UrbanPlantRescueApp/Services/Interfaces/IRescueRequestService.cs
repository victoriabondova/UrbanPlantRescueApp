namespace UrbanPlantRescueApp.Services.Interfaces
{
    public interface IRescueRequestService
    {
        Task CreateRescueRequestAsync(int plantId, string requesterId);
    }
}
