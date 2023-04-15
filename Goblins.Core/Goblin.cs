using Goblins.Core.Tools;

namespace Goblins.Core
{
    public record Goblin
    {
        public string? Name { get; set; }
        public Colour Colour { get; set; }
        public ITool[] Tools { get; set; } = Array.Empty<ITool>();
    }

    public enum Colour
    {
        Red = 0,
        Green = 1,
        Blue = 2,
    }

}
