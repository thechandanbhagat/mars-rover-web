using MarsRover.API.ViewModels;

namespace MarsRover.API
{
    public interface ICommandCenter
    {
        /// <summary>
        /// Executes the given string of commands for the rover
        /// </summary>
        void ExecuteCommands(string[] commands);

        /// <summary>
        /// Returns the list of coordinates step by step of the rover with x, y, step number and direction.
        /// </summary>

        List<RoverCoordinates> Steps { get; }
    }
}