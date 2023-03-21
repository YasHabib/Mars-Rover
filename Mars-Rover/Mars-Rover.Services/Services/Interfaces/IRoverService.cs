using Mars_Rover.Models.Entities;
using Mars_Rover.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mars_Rover.Services.Services.Interfaces
{
    public interface IRoverService
    {
        //------Basic CRUD operations---------
        Task CreateRover(string roverName);
        Task<List<RoverViewModel>> GetRoverList();

        //------Rover's movement operations------
        //string TurnLeft(string orientation);
        //string TurnRight(string orientation);
        //int MoveForward(int x, int y, string orientation);
        Task MoveRover(RoverInputsVIewModel roverInputs);
        Task<Coordinates> RoverDestination(string routeInstruction);


        Task SaveScreenshot(string screenshotName);
        Task<UpperCoordinateViewModel> ResizeGrid(int x, int y);
        Task<InitialPositionViewModel> SetInitialPosition(int x, int y, string orientation);
        Task<List<RoverHistoryViewModel>> GetRoverHistory();
        Task<string> GetOutput(RoverInputsVIewModel roverInputs);
    }
}
