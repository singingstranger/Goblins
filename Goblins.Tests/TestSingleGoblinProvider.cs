using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests
{
    internal class TestSingleGoblinProvider : IGoblinProvider
    {
        private readonly int count;
        private readonly Colour colour;
        private readonly ITool? tool;

        public TestSingleGoblinProvider(int count, Colour colour, ITool? tool)
        {
            this.count = count;
            this.colour = colour;
            this.tool = tool;
        }

        public int GetEggCount() => 
            count;

        public Colour GetRandomGoblinColour() => 
            colour;

        public ITool[] GetRandomTools() =>
            tool is null ? Array.Empty<ITool>() : new[] { tool };

    }
}