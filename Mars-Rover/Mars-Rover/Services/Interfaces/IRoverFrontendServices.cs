using Mars_Rover.Models.ViewModels;

namespace Mars_Rover.Services.Interfaces
{
    public interface IRoverFrontendServices
    {
        Task<List<RoverHistoryViewModel>> ViewRoverHistory();
    }
}
