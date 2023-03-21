namespace Mars_Rover.Models.Entities
{
    public class TestCoordinates
    {
        public int XCoordinate;
        public int YCoordinate;
        public string Orientation;

        public TestCoordinates(string currentPosition)
        {
            Int32.TryParse(currentPosition.Split(" ")[0], out XCoordinate);
            Int32.TryParse(currentPosition.Split(" ")[1], out YCoordinate);
            Orientation = currentPosition.Split(" ")[2];

        }
        public void TurnLeft()
        {
            switch (Orientation)
            {
                 case "N":
                    Orientation = "W"; break;
                case "W":
                    Orientation = "S"; break;
                 case "S":
                    Orientation = "E"; break;
                case "E":
                    Orientation = "N"; break;
                default:
                    throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");

            }
        }

        public void TurnRight()
        {
            switch (Orientation)
            {
                case "N":
                    Orientation = "E"; break;
                case "E":
                    Orientation = "S"; break;
                case "S":
                    Orientation = "W"; break;
                case "W":
                    Orientation = "N"; break;
                default:
                    throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
            }
        }

        public void MoveForward()
        {

            //int newX;
            //int newY;
            //string newOrientation;  
            switch (Orientation)
            {
                case "N":
                    YCoordinate += 1; break;
                case "E":
                    XCoordinate += 1; break;
                case "S":
                    YCoordinate -= 1; break;
                case "W":
                    XCoordinate -= 1; break;
                default:
                    throw new Exception("Unidefined parameter entered, please use this format X Y Orientation");
            }
        }
    }
}
