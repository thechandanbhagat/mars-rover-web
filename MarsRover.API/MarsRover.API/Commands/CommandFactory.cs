namespace MarsRover.API.Commands
{
    /// <summary>
    /// Factory for instantiating new command objects.
    /// </summary>
    public static class CommandFactory
    {
        private const char RotateRightCommand = 'R';
        private const char RotateLeftCommand = 'L';
        private const char MoveForwardCommand = 'M';

        /// <summary>
        /// Returns the command object based on the passed characters.
        /// </summary>
        public static bool TryGetCommand(char command, out IMoveCommand moveCommand)
        {
            switch (char.ToUpper(command))
            {
                case RotateRightCommand:
                    moveCommand = new RightCommand();
                    return true;

                case RotateLeftCommand:
                    moveCommand = new LeftCommand();
                    return true;

                case MoveForwardCommand:
                    moveCommand = new ForwardCommand();
                    return true;

                default:
                    moveCommand = null;
                    return false;
            }
        }
    }
}