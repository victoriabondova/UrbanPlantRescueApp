namespace UrbanPlantRescueApp.Services.Interfaces
{
    using UrbanPlantRescueApp.ViewModels;
    public interface IRescueRequestService
    {
        Task CreateRescueRequestAsync(int plantId, string requesterId);
        Task<IEnumerable<RescueRequestViewModel>> GetRequestsByPlantIdAsync(int plantId);
    }
}
