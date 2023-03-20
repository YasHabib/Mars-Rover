using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.ViewModels
{
    public class RoverInputsVIewModel
    {
        public Guid RoverId { get; set; }
        [Required]
        public string RoverPosition { get; set; } = string.Empty;
        [Required]
        public string RouteInstructions { get; set; } = string.Empty;
    }
}
