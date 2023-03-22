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
        //------Basic CRUD operations--------
        //Endpoint only access from Swagger UI there are not requirement to create rover for the end user
        Task CreateRover(string roverName);
        Task<List<RoverViewModel>> GetRoverList();

        //------Rover's movement operations------
        Task MoveRover(RoverInputsViewModel roverInputs);
        Task<TestCoordinates> RoverDestination(string routeInstruction);

        //Based on the rover(s) the end user selects, this will open empty input field to the end user.
        Task<RoverInputsViewModel> InputFieldsBasedOnSelectedRoverIds(Guid roverIds);

        Task SaveScreenshot(string screenshotName);
        Task<CoordinateViewModel> ResizeGrid(int x, int y);
        Task<List<RoverHistoryViewModel>> GetRoverHistory();

        //Get the output and save the rover movement data into database
        Task<string> GetOutput(RoverInputsViewModel roverInputs);
    }
}
