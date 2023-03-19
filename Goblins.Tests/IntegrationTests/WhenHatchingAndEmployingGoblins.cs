using FluentAssertions;
using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests.IntegrationTests
{
    public class WhenHatchingAndEmployingGoblins
    {
        const int GoblinCount = 10;
        private IEnumerable<Goblin> employedGoblins;

        public WhenHatchingAndEmployingGoblins() =>
            employedGoblins = new GoblinEmploymentAgency()
                .Employ(
                    new GoblinHatchery(
                        new TestGoblinProvider(GoblinCount, Colour.Green, new Pickaxe())
                        ).Hatch().Union(new GoblinHatchery ( new TestGoblinProvider(GoblinCount, Colour.Green, new Pen())).Hatch()));

        [Fact]
        public void ThenAllGoblinsGetJobs() =>
            employedGoblins.Should().AllSatisfy(goblin => goblin.Job.Should().NotBeNullOrEmpty());
        
        [Fact]
        public void ThenRedPickaxeGoblinsAreMiners() =>
            employedGoblins
                .Where(goblin => goblin.Colour == Colour.Red)
                .Where(goblin => goblin.Tools.OfType<Pickaxe>().Any())
                .Should()
                .AllSatisfy(goblin => goblin.Job.Should().Be("Miner"));
        
        [Fact]
        public void ThenRedPenGoblinsAreWriters() =>
            employedGoblins
                .Where(goblin => goblin.Colour == Colour.Red)
                .Where(goblin => goblin.Tools.OfType<Pen>().Any())
                .Should()
                .AllSatisfy(goblin => goblin.Job.Should().Be("Writer"));
    }
}
