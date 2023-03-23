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

        /// <summary>
        /// Creates a rover by taking a string as the name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpPost("create/rover")]
        public async Task<ActionResult> CreateRover(string name)
        {
            await _roverInterface.CreateRover(name);
            return Ok();
        }

        /// <summary>
        /// Takes a string (ie.  "5 5"), and retuns as x/y coordinates
        /// </summary>
        /// <param name="xycoordinates"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets a list of rovers
        /// </summary>
        /// <returns></returns>
        [HttpGet("rovers")]
        public async Task<ActionResult<List<RoverViewModel>>> GetRoverList()
        {
            var results = await _roverInterface.GetRoverList();
            return Ok(results);
        }

        /// <summary>
        /// Gets a list of rovers with their position history
        /// </summary>
        /// <returns></returns>

        [HttpGet("rover-history")]
        public async Task<ActionResult<List<RoverHistoryViewModel>>> GetRoverHistory()
        {
            var results = await _roverInterface.GetRoverHistory();
            return Ok(results);
        }

        /// <summary>
        /// Converts the list of coordinate and outputs 2 list of integers as X and Y coordinates
        /// </summary>
        /// <param name="roverPositionId"></param>
        /// <returns></returns>
        [HttpGet("coordinates")]
        public async Task<List<List<int>>> GetCoordinates(Guid roverPositionId)
        {
            var results = await _roverInterface.MoveRover(roverPositionId);
            return results;
        }

        /// <summary>
        /// Retrieves a list of rovers based on the ID selected by the end user
        /// </summary>
        /// <param name="roverIds"></param>
        /// <returns></returns>
        [HttpGet("roverListByIds")]
        public async Task<List<RoverViewModel>> GetRoversByIds([FromQuery] List<Guid> roverIds)
        {
            var results = await _roverInterface.GetRoversBasedOnIds(roverIds);
            return results;
        }

        //-------------------Output----------------------
        /// <summary>
        /// Takes the rover-input (line 1 and line 2), converts it to the final output, converts that data into the coordinates the rover took and save all these data into repository
        /// </summary>
        /// <param name="roverInputs"></param>
        /// <returns></returns>
        [HttpPost("rovers/input")]
        public async Task<ActionResult<string>> GetOutputBasedOnRoverInputs([FromBody]RoverInputsViewModel roverInputs)
        {
            var output = await _roverInterface.GetOutput(roverInputs);
            return output;
        }


    }
}
