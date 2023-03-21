using Mars_Rover.Models.Entities;
using Mars_Rover.Models.Objects;
using Microsoft.AspNetCore.Mvc;

namespace Mars_Rover.Models.ViewModels
{
    [BindProperties]
    public class RoverHistoryViewModel
    {
        public RoverHistoryViewModel(RoverPosition roverPosition)
        {
            RoverName = roverPosition.Rover.Name;
            UserInput = roverPosition.UserInput;
            OutputResult = roverPosition.OutputResult;
            CreatedDate = roverPosition.CreatedDate;

        }

        //public int Id { get; set; }
        public string RoverName { get; set; } = string.Empty;
        public string UserInput { get; set; } =string .Empty;
        public string OutputResult { get; set; } = string .Empty;
        public DateTime CreatedDate { get; set; }
    }
}
