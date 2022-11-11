using MarsRover.API.Commands;

namespace MarsRover.API
{
    ///<inheritdoc cref="IRover"/>
    public class Rover : IRover
    {
        public IPosition CurrentPosition { get; private set; }

        /// <summary>
        /// Creates a new instance of the class <see cref="Rover"/> with the given starting <see cref="IPosition"/>.
        /// </summary>
        public Rover(IPosition startingPosition)
        {
            CurrentPosition = startingPosition;
        }

        

        public void Move(IMoveCommand moveCommand)
        {
            CurrentPosition = moveCommand.Execute(CurrentPosition);
        }
    }
}