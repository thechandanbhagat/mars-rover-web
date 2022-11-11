namespace MarsRover.API.Commands
{
    /// <summary>
    /// A command to rotate right from the current position.
    /// </summary>
    public class RightCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            switch (currentPosition.Direction)
            {
                case Direction.North:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.East };

                case Direction.East:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.South };

                case Direction.South:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.West };

                default:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y, Direction = Direction.North };
            }
        }
    }
}