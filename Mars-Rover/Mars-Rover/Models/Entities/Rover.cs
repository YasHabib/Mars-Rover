using Mars_Rover.Models.Entities;
using Mars_Rover.Models.Entities.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace Mars_Rover.Models.Objects
{
    public class Rover : BaseEntity<Guid>,IDated
    {

        //Constructor for creating a rover
        public Rover(string name)
        {
            Name = name;
        }
        [Required]
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate {get; set;}
        public ICollection<RoverPosition>? RoverPositions { get; set; }
    }
}
