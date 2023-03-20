using Xunit.Abstractions;

namespace Goblins.Core
{
    public class GoblinHatchery
    {
        private readonly IGoblinProvider goblinProvider;
        private readonly ITestOutputHelper outputHelper;

        public GoblinHatchery(IGoblinProvider goblinProvider, ITestOutputHelper outputHelper = null)
        {
            this.goblinProvider = goblinProvider;
            this.outputHelper = outputHelper;
            int goblinCount = goblinProvider.GetEggCount();
            outputHelper.WriteLine("Goblin Count is: "+goblinCount);
        }
            

        public IEnumerable<Goblin> Hatch() =>
            Enumerable.Range(0, goblinProvider.GetEggCount())
                .Select(i =>
                {
                    outputHelper.WriteLine($"Hatching goblin {i}");

                    return new Goblin()
                    {
                        Name = $"Goblin number {i}",
                        Colour = goblinProvider.GetRandomGoblinColour(),
                        Tools = new[] { goblinProvider.GetRandomTool() }
                    };
                });
    }
}