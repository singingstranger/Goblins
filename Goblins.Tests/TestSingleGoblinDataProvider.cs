using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests
{
    internal class TestSingleGoblinDataProvider : IGoblinDataProvider
    {
        private readonly int count;
        private readonly Colour colour;
        private readonly ITool? tool;

        public TestSingleGoblinDataProvider(int count, Colour colour, ITool? tool)
        {
            this.count = count;
            this.colour = colour;
            this.tool = tool;
        }

        public int GetEggCount() => 
            count;

        public Colour GetColour(int index) => 
            colour;

        public ITool[] GetTools(int index) =>
            tool is null ? Array.Empty<ITool>() : new[] { tool };

    }
}