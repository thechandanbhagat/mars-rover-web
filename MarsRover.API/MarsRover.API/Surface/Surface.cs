using MarsRover.API;

namespace MarsRover.API
{
    public class Surface : ISurface
    {
        public uint Width { get; private set; }
        public uint Length { get; private set; }

        public Surface(uint width, uint length)
        {
            Width = width;
            Length = length;
        }

        public Surface()
        {
            Width = 5;
            Length = 5;
        }

        public bool IsPointInside(IPosition pointPosition)
        {
            return pointPosition.X <= Width
                    && pointPosition.Y <= Length
                    && pointPosition.X >= 0
                    && pointPosition.Y >= 0;
        }
    }
}