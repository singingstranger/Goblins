namespace Goblins.Core
{
    public class GoblinHatchery
    {
        private readonly IGoblinProvider goblinProvider;

        public GoblinHatchery(IGoblinProvider goblinProvider) => 
            this.goblinProvider = goblinProvider;


        public IEnumerable<Goblin> Hatch() =>
            Enumerable.Range(0, goblinProvider.GetEggCount())
                .Select(i =>
                {
                    return new Goblin()
                    {
                        Name = $"Goblin number {i}",
                        Colour = goblinProvider.GetRandomGoblinColour(),
                        Tools = goblinProvider.GetRandomTools()
                    };
                });
    }
}