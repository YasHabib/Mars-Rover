using Mars_Rover.Models.Entities;

namespace Mars_Rover.Models.ViewModels
{
    public class RoverViewModel
    {
        public RoverViewModel() { }
        public RoverViewModel(Rover rover)
        {
            Id = rover.Id;
            Name = rover.Name;
            CreatedDate = rover.CreatedDate;
        }
        public Guid Id { get; set; }
        public string Name { get; set; } = string.Empty;
        public DateTime CreatedDate { get; set; }
    }
}
