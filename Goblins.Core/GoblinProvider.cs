using Goblins.Core.Tools;

namespace Goblins.Core
{
    public class GoblinProvider : IGoblinProvider
    {
        private Random random = new Random();
        public Type[] ToolTypes = new[] { typeof(Pickaxe), typeof(Pen) };
        public int GetEggCount() => 
            random.Next(50);

        public Colour GetRandomGoblinColour() =>
            Enum.GetValues(typeof(Colour))
                .Cast<Colour>()
                .OrderBy(colour => random.Next())
                .First();

        public ITool? GetRandomTool() => 
            Activator.CreateInstance(ToolTypes[random.Next(ToolTypes.Count())]) as ITool;
    }
}
