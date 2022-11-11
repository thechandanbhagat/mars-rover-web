namespace MarsRover.API.Commands
{
    public interface IMoveCommand
    {
        /// <summary>
        /// Executes the movement command based on the current position and returns the new position.
        /// </summary>
        public IPosition Execute(IPosition currentPosition);
    }
}