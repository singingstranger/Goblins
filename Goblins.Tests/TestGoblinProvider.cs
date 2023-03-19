using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests
{
    internal class TestGoblinProvider : IGoblinProvider
    {
        List<Goblin> goblins = new List<Goblin>();
        int numberOfTimesColourWasCounted = 0;
        int numberOfTimesToolWasCounted = 0;

        public TestGoblinProvider()
        {
            goblins.Add(new Goblin()
            {
                Colour = Colour.Red,
                Tools = new [] {new Pen()},
                Name = "Boris"
            });
            goblins.Add(new Goblin()
            {
                Colour = Colour.Red,
                Tools = new [] {new Pickaxe()},
                Name = "Dennis"
            });
            goblins.Add(new Goblin()
            {
                Colour = Colour.Blue,
                Tools = new [] {new Pen()},
                Name = "Hanna"
            });
            goblins.Add(new Goblin()
            {
                Colour = Colour.Green,
                Name = "Steve"
            });
            goblins.Add(new Goblin()
            {
                Colour = Colour.Red,
                Tools = new ITool[] {new Pen(), new Pickaxe()},
                Name = "Geroge"
            });
            goblins.Add(new Goblin()
            {
                Name = "Void"
            });
        }

        public int GetEggCount() =>
            goblins.Count();
        
            

        public Colour GetRandomGoblinColour()
        {
            var color = goblins[numberOfTimesColourWasCounted].Colour;
            numberOfTimesColourWasCounted++;
            return color;
        }
            

        public ITool? GetRandomTool() 
        {
            var tool = goblins[numberOfTimesToolWasCounted].Tools;
            numberOfTimesToolWasCounted++;
            return tool.FirstOrDefault();
        }
            //goblins[numberOfTimesToolWasCounted++].Tools.FirstOrDefault();
            
    }
}