using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests
{
    internal class TestGoblinProvider : IGoblinProvider
    {
        private readonly int count;
        private readonly Colour colour;
        private readonly ITool? tool;

        public TestGoblinProvider(int count, Colour colour, ITool? tool)
        {
            this.count = count;
            this.colour = colour;
            this.tool = tool;
        }

        public int GetEggCount() => 
            count;

        public Colour GetRandomGoblinColour() => 
            colour;

        public ITool? GetRandomTool() => 
            tool;
    }
}