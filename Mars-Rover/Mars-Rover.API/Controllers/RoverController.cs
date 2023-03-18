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
        private readonly IRoverInterface _roverInterface;

        public RoverController(IRoverInterface roverInterface)
        {
            _roverInterface = roverInterface;   
        }

        [HttpPost]
        public async Task<string> GetOutputBasedOnRoverInputs(RoverInputsVIewModel roverInputs)
        {
            var output = await _roverInterface.GetOutput(roverInputs);
            return output;
        }
    }
}
