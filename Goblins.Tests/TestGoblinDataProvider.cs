using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests
{
    internal class TestGoblinDataProvider : IGoblinDataProvider
    {
        IList<TestGoblinData> goblinData = new List<TestGoblinData>()
        {
            new(Colour.Red, new [] {new Pen()}),
            new(Colour.Red, new [] {new Pickaxe()}),
            new(Colour.Blue, new [] {new Pen()}),
            new(Colour.Green, Array.Empty<ITool>()),
            new(Colour.Red, new ITool[] { new Pen(), new Pickaxe() }),
        };
        internal record class TestGoblinData(Colour Colour, ITool[] Tools);

        public int GetEggCount() =>
            goblinData.Count();

        public Colour GetColour(int index) =>
            goblinData[index].Colour;

        public ITool[] GetTools(int index) =>
            goblinData[index].Tools;
            
    }
}