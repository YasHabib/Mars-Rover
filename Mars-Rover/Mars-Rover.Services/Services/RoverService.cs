using Mars_Rover.Models.Entities;
using Mars_Rover.Models.ViewModels;
using Mars_Rover.Services.Services.Interfaces;

namespace Mars_Rover.Services.Services
{
    public class RoverService :IRoverInterface
    {
        public Task<List<RoverViewModel>> GetRoverHistory(RoverPosition roverPosition)
        {
            throw new NotImplementedException();
        }

        public Task MoveRover(RoverInputsVIewModel roverInputs)
        {
            throw new NotImplementedException();
        }

        public async Task<string> GetOutput(RoverInputsVIewModel roverInputs)
        {
            throw new NotImplementedException();
        }

        public Task SaveScreenshot(string screenshotName)
        {
            throw new NotImplementedException();
        }

        public Task SaveUpperGridCoordinates(string xy)
        {
            throw new NotImplementedException();
        }
    }
}
