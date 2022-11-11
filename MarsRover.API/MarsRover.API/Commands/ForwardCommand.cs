namespace MarsRover.API.Commands
{
    /// <summary>
    /// a command to move forward
    /// </summary>
    public class ForwardCommand : IMoveCommand
    {
        public IPosition Execute(IPosition currentPosition)
        {
            switch (currentPosition.Direction)
            {
                case Direction.North:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y + 1, Direction = currentPosition.Direction };

                case Direction.East:
                    return new Position() { X = currentPosition.X + 1, Y = currentPosition.Y, Direction = currentPosition.Direction };

                case Direction.South:
                    return new Position() { X = currentPosition.X, Y = currentPosition.Y - 1, Direction = currentPosition.Direction };

                default:
                    return new Position() { X = currentPosition.X - 1, Y = currentPosition.Y, Direction = currentPosition.Direction };
            }
        }
    }
}