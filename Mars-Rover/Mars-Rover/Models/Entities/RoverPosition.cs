using Mars_Rover.Models.Entities.Interfaces;
using Mars_Rover.Models.Objects;
using Mars_Rover.Models.ViewModels;
using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.Entities
{
    public class RoverPosition:BaseEntity<Guid>,IDated
    {
        public RoverPosition()
        {
            
        }
        //Constructor to add a rover's position into database
        public RoverPosition(RoverInputsVIewModel roverData, Guid roverId, string output, List<int> coordinates)
        {
            RoverId = roverId;
            UserInput = roverData.InitialPosition + ": " + roverData.RouteInstructions;
            OutputResult = output;
            XYCoordinates = coordinates;

        }
        public Guid RoverId { get; set; }
        public Rover? Rover { get; set; }
        public string UserInput { get; set; } = string.Empty;
        //public string ScreenshotIds { get; set; } = string.Empty;
        public string OutputResult { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
        public List<int>? XYCoordinates { get; set; }

    }
}
