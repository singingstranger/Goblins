using Goblins.Core.Tools;

namespace Goblins.Core
{
    public class RandomGoblinDataProvider : IGoblinDataProvider
    {
        private Random random = new Random();
        public Type[] ToolTypes = new[] { typeof(Pickaxe), typeof(Pen) };

        public int GetEggCount() => 
            random.Next(50);

        public Colour GetColour(int index) =>
            Enum.GetValues(typeof(Colour))
                .Cast<Colour>()
                .OrderBy(colour => random.Next())
                .First();

        public ITool[] GetTools(int index) => 
             new [] { (ITool)Activator.CreateInstance(ToolTypes[random.Next(ToolTypes.Count())])! };

    }
}
