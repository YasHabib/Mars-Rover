using Mars_Rover.Models.Entities;
using Mars_Rover.Models.ViewModels;
using Mars_Rover.Repository;
using Mars_Rover.Repository.Interfaces;
using Mars_Rover.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Syncfusion.EJ2.Maps;
using Syncfusion.EJ2.Notifications;
using System.Linq;
using System.Text.RegularExpressions;

namespace Mars_Rover.Services.Services
{
    public class RoverService :IRoverService
    {

        private readonly IUnitOfWork _unitOfWork;
        public RoverService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }

        //------------------Create----------------------------//
        public async Task CreateRover(string roverName)
        {
            var rover = new Rover(roverName);
            _unitOfWork.Rovers.Create(rover);
            await _unitOfWork.SaveAsync();
        }
        

        //----------------------Read-------------------------//

        public async Task<List<RoverViewModel>> GetRoverList()
        {
            var results = await _unitOfWork.Rovers.GetAll();
            var models = results.Select(lists => new RoverViewModel(lists)).ToList();
            return models;
        }

        public async Task<List<RoverHistoryViewModel>> GetRoverHistory()
        {
            var results = await _unitOfWork.RoverPositions.GetAll(i => i.Include(i => i.Rover).OrderBy(i => i.Rover.Name).ThenByDescending(i => i.CreatedDate));
            var models = results.Select(lists => new RoverHistoryViewModel(lists)).ToList();   
            return models;
        }

        public async Task<List<List<int>>> MoveRover(Guid roverPositionId)
        {
            var roverPosition = await _unitOfWork.RoverPositions.GetById(roverPositionId);
            var coordinates = roverPosition.XYCoordinates.ToList();
            List<int> Xcoords = new List<int>();
            List<int> Ycoords = new List<int>();

            for (int i = 0; i < coordinates.Count; i++)
            {
                if(i % 2 == 0) Xcoords.Add(coordinates[i]);
                else Ycoords.Add(coordinates[i]);
            }

            return new List<List<int>> { Xcoords , Ycoords };
        }

        public async Task<List<RoverViewModel>> GetRoversBasedOnIds(List<Guid> roverIds)
        {
            List<RoverViewModel> roverModels = new List<RoverViewModel>();
            foreach (var roverId in roverIds)
            {
                var rover = await _unitOfWork.Rovers.GetById(roverId);
                var model = new RoverViewModel(rover);
                roverModels.Add(model);
            }
            return roverModels;
        }


        public async Task<string> GetOutput(RoverInputsViewModel roverInputs)
        {


            //------------Setting initial position and location of rover------------
            string[] roverPosition = roverInputs.InitialPosition.Split(" ");

            int positionX;
            int positionY;
            Int32.TryParse(roverPosition[0], out positionX);
            Int32.TryParse(roverPosition[1], out positionY);
            var positionOrientation = roverPosition[2];

            //adding initial position to a list of coordinates.NOTE: even index are X and odd index are Y
            List<int> xyCoordinates = new List<int>();
            xyCoordinates.Add(positionX);
            xyCoordinates.Add(positionY);

            //---------Breaking down rover instruction---------------
            char[] routeInstruction = roverInputs.RouteInstructions.ToCharArray();

            for (int i = 0; i<routeInstruction.Length; i++)
            {

                switch (routeInstruction[i])
                {
                    case 'L':
                        switch (positionOrientation)
                        {
                            case "N":
                                positionOrientation = "W"; break;
                            case "W":
                                positionOrientation = "S"; break;
                            case "S":
                                positionOrientation = "E"; break;
                            case "E":
                                positionOrientation = "N"; break;
                            default:
                                throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
                        }
                        break;
                    case 'R':
                        switch (positionOrientation)
                        {
                            case "N":
                                positionOrientation = "E"; break;
                            case "E":
                                positionOrientation = "S"; break;
                            case "S":
                                positionOrientation = "W"; break;
                            case "W":
                                positionOrientation= "N"; break;
                            default:
                                throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
                        }
                        break;
                    case 'M':
                        switch (positionOrientation)
                        {
                            case "N":
                                positionY += 1;
                                xyCoordinates.Add(positionX);
                                xyCoordinates.Add(positionY);
                                break;
                            case "E":
                                positionX += 1;
                                xyCoordinates.Add(positionX);
                                xyCoordinates.Add(positionY);
                                break;
                            case "S":
                                positionY -= 1;
                                xyCoordinates.Add(positionX);
                                xyCoordinates.Add(positionY);
                                break;
                            case "W":
                                positionX -= 1;
                                xyCoordinates.Add(positionX);
                                xyCoordinates.Add(positionY);
                                break;
                            default:
                                throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
                        }
                        break;
                    default: throw new Exception("Unidefined parameter entered, please use either L, R or M");
                }
            }

            var output = positionX.ToString() + " " + positionY.ToString() + " "+ positionOrientation;

            //saving the data
            var rover = await _unitOfWork.Rovers.GetById(roverInputs.RoverId);

            var roverPositionData = new RoverPosition(roverInputs, rover.Id, output, xyCoordinates);

            roverPositionData.RoverId = rover.Id;
            roverPositionData.UserInput = roverInputs.InitialPosition + ", " + roverInputs.RouteInstructions;
            roverPositionData.OutputResult = output;
            roverPositionData.XYCoordinates = xyCoordinates;

            _unitOfWork.RoverPositions.Create(roverPositionData);
            await _unitOfWork.SaveAsync();

            //returning output as response
            return output;
        }

        public Task SaveScreenshot(string screenshotName)
        {
            throw new NotImplementedException();
        }

        public Task<CoordinateViewModel> ResizeGrid(int x, int y)
        {
            var coordinates = new CoordinateViewModel();
            coordinates.XCoordinate = x;
            coordinates.YCoordinate = y;
            return Task.FromResult(coordinates);
        }

        //-------------Helper methods-----------

    }
}
