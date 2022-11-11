namespace MarsRover.API
{
    /// <summary>
    /// Represents a 2d surface.
    /// </summary>
    public interface ISurface
    {
        /// <summary>
        /// The width of the surface.
        /// </summary>
        uint Width { get; }

        /// <summary>
        /// The length of the surface.
        /// </summary>
        uint Length { get; }

        /// <summary>
        /// Indicates whether the given point is within the boundaries of the surface.
        /// </summary>
        //todo : look after the if the point is within the surface
        bool IsPointInside(IPosition pointPosition);
    }
}