namespace MarsRover.API.ViewModels
{
    public class ResponseViewModel
    {
        public string Message { get; set; }
        public List<RoverCoordinates> Rovers { get; set; }
    }

    public class RoverCoordinates
    {
        public List<CoordinatesSteps> Steps { get; set; }

    }

    public class CoordinatesSteps
    {
        public uint Step { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }
    }
}