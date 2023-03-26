namespace Goblins.Core
{
    public class GoblinHatchery
    {
        private readonly IGoblinDataProvider goblinProvider;

        public GoblinHatchery(IGoblinDataProvider goblinProvider) => 
            this.goblinProvider = goblinProvider;


        public IEnumerable<Goblin> Hatch() =>
            Enumerable.Range(0, goblinProvider.GetEggCount())
                .Select(i =>
                {
                    return new Goblin()
                    {
                        Name = $"Goblin number {i}",
                        Colour = goblinProvider.GetColour(i),
                        Tools = goblinProvider.GetTools(i)
                    };
                });
    }
}