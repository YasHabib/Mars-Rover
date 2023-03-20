using Mars_Rover.Models.ViewModels;
using Mars_Rover.Services.Services.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Mars_Rover.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RoverController : ControllerBase
    {
        private readonly IRoverService _roverInterface;

        public RoverController(IRoverService roverInterface)
        {
            _roverInterface = roverInterface;   
        }

        [HttpPost("create/rover")]
        public async Task<ActionResult> CreateRover(string name)
        {
            await _roverInterface.CreateRover(name);
            return Ok();
        }

        [HttpGet("rovers")]
        public async Task<ActionResult<List<RoverViewModel>>> GetRoverList()
        {
            var results = await _roverInterface.GetRoverList();
            return Ok(results);
        }

        [HttpPost("setGridLimit")]
        public async Task<ActionResult> SetGridLimit(string xycoordinates)
        {
            string[] xy = xycoordinates.Split(" ");
            var upperX = Int32.Parse(xy[0]);
            var upperY = Int32.Parse(xy[1]);
            var result = await _roverInterface.ResizeGrid(upperX, upperY);
            return Ok(result);
        }

        [HttpPost("inputs")]
        public async Task<ActionResult<string>> GetOutputBasedOnRoverInputs(RoverInputsVIewModel roverInputs)
        {
            //Getting upper right corner coordinates
            //string[] upperLimit = roverInputs.UpperCoordinates.Split(" ");
            //var upperX = Int32.Parse(upperLimit[0]);
            //var upperY = Int32.Parse(upperLimit[1]);
            //await _roverInterface.ResizeGrid(upperX, upperY);

            //Getting rover's current position
            string[] roverPosition = roverInputs.RoverPosition.Split(" ");
            //int positionX = Int32.Parse(roverPosition[0]);
            //int positionY = Int32.Parse(roverPosition[1]);
            //var positionOrientation = roverPosition[2];
            int positionX;
            int positionY;
            Int32.TryParse(roverPosition[0], out positionX);
            Int32.TryParse(roverPosition[1], out positionY);
            var positionOrientation = roverPosition[2];

            _roverInterface.TurnLeft(positionOrientation);
            _roverInterface.TurnRight(positionOrientation);
            _roverInterface.MoveForward(positionX, positionY, positionOrientation);
            

            await _roverInterface.SetInitialPosition(positionX, positionY, positionOrientation);

            var output = await _roverInterface.GetOutput(roverInputs);
            return output;
        }


    }
}
