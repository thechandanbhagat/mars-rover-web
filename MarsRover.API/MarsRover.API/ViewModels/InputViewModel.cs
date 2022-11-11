using Newtonsoft.Json;

namespace MarsRover.API.ViewModels
{
    public class InputViewModel
    {
        [JsonProperty("surface")]
        public SurfaceViewModel Surface { get; set; }

        [JsonProperty("position")]
        public PositionViewModel Position { get; set; }

        [JsonProperty("commands")]
        public string[] Commands { get; set; }
    }

    public class SurfaceViewModel
    {
        [JsonProperty("width")]
        public uint Width { get; set; }

        [JsonProperty("height")]
        public uint Height { get; set; }
    }

    public class PositionViewModel
    {
        [JsonProperty("x")]
        public int X { get; set; }

        [JsonProperty("y")]
        public int Y { get; set; }

        [JsonProperty("orientation")]
        public Direction Orientation { get; set; }
    }
}