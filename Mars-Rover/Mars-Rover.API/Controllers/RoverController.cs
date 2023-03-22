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
        //----------------------Create --------------------------

        [HttpPost("create/rover")]
        public async Task<ActionResult> CreateRover(string name)
        {
            await _roverInterface.CreateRover(name);
            return Ok();
        }

        [HttpPost("setGridLimit")]
        public async Task<ActionResult<CoordinateViewModel>> SetGridLimit([FromBody] string xycoordinates)
        {
            string[] xy = xycoordinates.Split(" ");
            var upperX = Int32.Parse(xy[0]);
            var upperY = Int32.Parse(xy[1]);
            var result = await _roverInterface.ResizeGrid(upperX, upperY);
            return Ok(result);
        }

        //-----------------------------retrieve data---------------------
        [HttpGet("rovers")]
        public async Task<ActionResult<List<RoverViewModel>>> GetRoverList()
        {
            var results = await _roverInterface.GetRoverList();
            return Ok(results);
        }

        [HttpGet("rover-history")]
        public async Task<ActionResult<List<RoverHistoryViewModel>>> GetRoverHistory()
        {
            var results = await _roverInterface.GetRoverHistory();
            return Ok(results);
        }

        [HttpGet("coordinates")]
        public async Task<List<List<int>>> GetCoordinates(Guid roverPositionId)
        {
            var results = await _roverInterface.MoveRover(roverPositionId);
            return results;
        }

        //-------------------Output----------------------
        [HttpPost("rovers/input")]
        public async Task<ActionResult<string>> GetOutputBasedOnRoverInputs([FromBody]RoverInputsViewModel roverInputs)
        {
            var output = await _roverInterface.GetOutput(roverInputs);
            return output;
        }


    }
}
