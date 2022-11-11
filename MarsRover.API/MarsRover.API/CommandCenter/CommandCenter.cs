using MarsRover.API.Commands;
using MarsRover.API.ViewModels;

namespace MarsRover.API
{
    public class CommandCenter : ICommandCenter
    {
        private readonly IRover _rover;
        private readonly ISurface _surface;
        private bool _invalidCommandFound;
        private List<RoverCoordinates> steps = new List<RoverCoordinates>();
        public List<RoverCoordinates> Steps => steps;

        public CommandCenter(IRover rover, ISurface surface)
        {
            _rover = rover;
            _surface = surface;
            CheckIfRoverIsInsideSurface();
        }

        /// <summary>
        /// Executes the command sent by the user.
        /// </summary>
        /// <param name="commands"></param>
        public void ExecuteCommands(string[] commands)
        {
            foreach (var item in commands)
            {
                uint counter = 0;
                var roverSteps = new List<CoordinatesSteps>();
                foreach (char c in item)
                {
                    ProcessCommand(c, counter, ref roverSteps);
                    counter++;
                }
                steps.Add(new RoverCoordinates() { Steps = roverSteps });
            }
        }

        private void ProcessCommand(char command, uint counter, ref List<CoordinatesSteps> roverCoordinates)
        {
            if (CommandFactory.TryGetCommand(command, out IMoveCommand moveCommand))
            {
                _rover.Move(moveCommand);
                roverCoordinates.Add(new CoordinatesSteps() { Step = counter, X = _rover.CurrentPosition.X, Y = _rover.CurrentPosition.Y, Direction = _rover.CurrentPosition.Direction });
                CheckIfRoverIsInsideSurface();
            }
            else
                _invalidCommandFound = true;
        }

        private void CheckIfRoverIsInsideSurface()
        {
            if (!_surface.IsPointInside(_rover.CurrentPosition))
                _invalidCommandFound = true;
        }
    }
}