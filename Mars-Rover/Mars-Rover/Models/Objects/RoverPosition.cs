using Mars_Rover.Models.Objects;
using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.Entities
{
    public class RoverPosition
    {
        [Key]
        public Guid Id { get; set; }
        public int RoverId { get; set; }
        public Rover Rover;
        public string UserInput { get; set; } = string.Empty;
        public string ScreenshotIds { get; set; } = string.Empty;
        public string OutputResult { get; set; } = string.Empty;
    }
}
