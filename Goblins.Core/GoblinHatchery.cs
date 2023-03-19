namespace Goblins.Core
{
    public class GoblinHatchery
    {
        private readonly IGoblinProvider goblinProvider;

        public GoblinHatchery(IGoblinProvider goblinProvider){
            this.goblinProvider = goblinProvider;
            int goblinCount = goblinProvider.GetEggCount();
            Console.Write("Goblin Count is: "+goblinCount);
        }
            

        public IEnumerable<Goblin> Hatch() =>
            Enumerable.Range(0, goblinProvider.GetEggCount())
                .Select(i => new Goblin()
                {
                    Name = $"Goblin number {i}",
                    Colour = goblinProvider.GetRandomGoblinColour(),
                    Tools = new[] { goblinProvider.GetRandomTool() }
                });
    }
}