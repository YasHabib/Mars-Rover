using Mars_Rover.Models.Entities;
using Mars_Rover.Models.Objects;
using Mars_Rover.Models.ViewModels;
using Mars_Rover.Repository.Interfaces;
using Mars_Rover.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using Syncfusion.EJ2.Notifications;
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

        public Task<List<RoverPositionViewModel>> GetRoverHistory()
        {
            throw new NotImplementedException();
        }

        public Task MoveRover(RoverInputsVIewModel roverInputs)
        {
            throw new NotImplementedException();
        }

        
        public async Task<string> GetOutput(RoverInputsVIewModel roverInputs)
        {
            //var rover = await _unitOfWork.Rovers.GetById(roverInputs.RoverId);

            //storing the input data in-memory
            //var roverPositionData = new RoverPosition(roverInputs, rover.Id, output);
            //roverPositionData.Id = rover.Id;
            //rover

            //string[] upperLimit = roverInputs.UpperCoordinates.Split(" ");


            //------------Setting initial position and location of rover------------
            string[] roverPosition = roverInputs.InitialPosition.Split(" ");

            int positionX;
            int positionY;
            Int32.TryParse(roverPosition[0], out positionX);
            Int32.TryParse(roverPosition[1], out positionY);
            var positionOrientation = roverPosition[2];

            //---------Breaking down rover instruction---------------
            char[] routeInstruction = roverInputs.RouteInstructions.ToCharArray();

            for (int i = 0; i<routeInstruction.Length; i++)
            {

                //switch(routeInstruction[i])
                //{
                //    case 'L': 
                //        newOrientation = TurnLeft(positionOrientation);           
                //        break;
                //    case 'R': 
                //        newOrientation = TurnRight(positionOrientation); 
                //        break;
                //    case 'M': 
                //        xyCheck = MoveForward(positionX, positionY, positionOrientation); 
                //        //if X coordinate has changed
                //        if(xyCheck == positionX)
                //        {
                //            newPositionX = xyCheck; newPositionY = positionY;
                //        }
                //        else
                //        {
                //            newPositionY = xyCheck; newPositionX = positionX;
                //        }
                //        break;
                //    default: throw new Exception("Unidefined parameter entered, please use either L, R or M");

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
                                positionY += 1; break;
                            case "E":
                                positionX += 1; break;
                            case "S":
                                positionY -= 1; break;
                            case "W":
                                positionX -= 1; break;
                            default:
                                throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
                        }
                        break;
                    default: throw new Exception("Unidefined parameter entered, please use either L, R or M");
                }
            }

            var output = positionX.ToString() + " " + positionY.ToString() + " "+ positionOrientation;

            return output;

            throw new NotImplementedException();


        }

        //----------------------Update-------------------------//

        public Task<Coordinates> RoverDestination(string routeInstruction)
        {
            throw new NotImplementedException();
        }

        public Task SaveScreenshot(string screenshotName)
        {
            throw new NotImplementedException();
        }

        public Task<UpperCoordinateViewModel> ResizeGrid(int x, int y)
        {
            var coordinates = new UpperCoordinateViewModel();
            coordinates.XCoordinate = x;
            coordinates.YCoordinate = y;
            return Task.FromResult(coordinates);
        }

        public Task<InitialPositionViewModel> SetInitialPosition(int x, int y, string orientation)
        {
            var coordinates = new InitialPositionViewModel();
            coordinates.CurrentPositionX = x;
            coordinates.CurrentPositionY = y;
            coordinates.CurrentOrientation = orientation;
            return Task.FromResult(coordinates);
        }


        ////-----------Helper methods------------
        //public string TurnLeft(string currentOrientation)
        //{
        //    switch(currentOrientation)
        //    {
        //        case "N":
        //            currentOrientation = "W";
        //            return currentOrientation;
        //        case "W":
        //            currentOrientation = "S"; 
        //            return currentOrientation;
        //        case "S":
        //            currentOrientation = "E"; 
        //            return currentOrientation;
        //        case "E":
        //            currentOrientation = "N"; 
        //            return currentOrientation;
        //        default:
        //            throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");

        //    }
        //}

        //public string TurnRight(string currentOrientation)
        //{
        //    switch (currentOrientation)
        //    {
        //        case "N":
        //            currentOrientation = "E";
        //            return currentOrientation;
        //        case "E":
        //            currentOrientation = "S";
        //            return currentOrientation;
        //        case "S":
        //            currentOrientation = "W";
        //            return currentOrientation;
        //        case "W":
        //            currentOrientation = "N";
        //            return currentOrientation;
        //        default:
        //            throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
        //    }
        //}

        //public int MoveForward(int x, int y, string orientation) 
        //{

        //    switch (orientation)
        //    {
        //        case "N":
        //            y += 1; return y;
        //        case "E":
        //            x += 1; return x;
        //        case "S":
        //            y -= 1; return y;
        //        case "W":
        //            x -= 1; return x;
        //        default:
        //            throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
        //    }
        //}
    }
}
