namespace MarsRover.API.Commands
{
    /// <summary>
    /// A command to rotate left from the current position.
    /// </summary>
    public class LeftCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            switch (currentPosition.Direction)
            {
                case Direction.North:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.West };

                case Direction.East:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.North };

                case Direction.South:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.East };

                default:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.South };
            }
        }
    }
}