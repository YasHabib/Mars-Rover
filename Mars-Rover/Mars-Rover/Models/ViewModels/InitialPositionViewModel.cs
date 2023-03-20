namespace Mars_Rover.Models.ViewModels
{
    public class InitialPositionViewModel
    {
        public int CurrentPositionX { get; set; }
        public int CurrentPositionY { get; set; }
        public string CurrentOrientation { get; set; } = string.Empty;
    }
}
