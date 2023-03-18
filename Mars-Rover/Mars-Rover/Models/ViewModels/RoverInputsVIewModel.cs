using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.ViewModels
{
    public class RoverInputsVIewModel
    {
        public int RoverId { get; set; }
        public string? UpperCoordinates { get; set; } = "5 5";
        [Required]
        public string RoverPosition { get; set; } = string.Empty;
        [Required]
        public string RouteInstructions { get; set; } = string.Empty;
    }
}
