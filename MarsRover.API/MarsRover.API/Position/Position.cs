namespace MarsRover.API
{
    ///<inheritdoc cref="IPosition"/>
    public class Position : IPosition
    {
        public int X { get; set; }
        public int Y { get; set; }
        public Direction Direction { get; set; }

        /// <summary>
        /// Creates a new <see cref="Position"/> with the given X and Y coordinates and <see cref="Direction.Direction"/>.
        /// </summary>
        ///

        public Position()
        {
        }

        //public Position(int x, int y, Direction orientation)
        //{
        //    X = x;
        //    Y = y;
        //    Orientation = orientation;
        //}
    }
}