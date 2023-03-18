using Mars_Rover.Models.Entities;
using Mars_Rover.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Services.Services.Interfaces
{
    public interface IRoverInterface
    {
        Task SaveScreenshot(string screenshotName);
        Task SaveUpperGridCoordinates(string xy);
        Task MoveRover(RoverInputsVIewModel roverInputs);
        Task<List<RoverViewModel>> GetRoverHistory(RoverPosition roverPosition);
        Task<string> GetOutput(RoverInputsVIewModel roverInputs);
    }
}
