using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.ViewModels
{
    public class RoverInputsViewModel
    {
        public Guid RoverId { get; set; }
        public string? RoverName { get; set;} 
        [Required]
        public string InitialPosition { get; set; } = string.Empty;
        [Required]
        public string RouteInstructions { get; set; } = string.Empty;
    }
}
