using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests
{
    public record class TestGoblinData(Colour Colour, ITool[] Tools);
    
    internal class TestGoblinDataProvider : IGoblinDataProvider
    {
        private IList<TestGoblinData> goblinData;

        public TestGoblinDataProvider(params TestGoblinData[] goblinData) =>
            this.goblinData = goblinData.ToList();


        public int GetEggCount() =>
            goblinData.Count();

        public Colour GetColour(int index) =>
            goblinData[index].Colour;

        public ITool[] GetTools(int index) =>
            goblinData[index].Tools;
            
    }
}