using Mars_Rover.Models.Entities;
using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.Objects
{
    public class Rover
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; } = string.Empty;
        //public ICollection<RoverPosition>? RoverPositions { get; set; }

        //In-memory Rovers data
        List<Rover> Rovers = new List<Rover>()
        {
            new Rover { Id = 1, Name = "Bob the Rover" },
            new Rover { Id = 2, Name = "Ms Rover" },
        }; 
    }
}
