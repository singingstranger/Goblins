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
                        ).Hatch());

        [Fact]
        public void ThenAllGoblinsGetJobs() =>
            employedGoblins.Should().AllSatisfy(goblin => goblin.Job.Should().NotBeNullOrEmpty());

    }
}
