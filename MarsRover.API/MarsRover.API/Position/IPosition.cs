namespace MarsRover.API
{
    /// <summary>
    /// Holds the X and Y position and direction of an rover in a 2d plane.
    /// </summary>
    public interface IPosition
    {
        int X { get; set; }
        int Y { get; set; }
        Direction Direction { get; set; }
    }
}