using MarsRover.API.Commands;

namespace MarsRover.API
{
    /// <summary>
    /// Represents a Rover that can be moved in a 2d plane.
    /// </summary>
    public interface IRover
    {
        /// <summary>
        /// The current position of the rover.
        /// </summary>
        public IPosition CurrentPosition { get; }

        /// <summary>
        /// To updates the position of the rover following the execution of the given command
        /// </summary>
        void Move(IMoveCommand moveCommand);
    }
}