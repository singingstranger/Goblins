using FluentAssertions;
using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests.IntegrationTests
{
    public class WhenHatchingAndEmployingGoblins
    {
        private IEnumerable<Goblin> employedGoblins = new GoblinEmploymentAgency()
                    .Employ(new GoblinHatchery(new TestGoblinDataProvider())
                        .Hatch());

        [Fact]
        public void ThenAllGoblinsGetJobs_FluentAllTheWayMode() =>
            employedGoblins
            .Should().AllSatisfy(goblin =>
            {
                goblin.Job.Should().NotBeNullOrEmpty();
                goblin.Name.Should().NotBeNullOrEmpty();

            });

        [Fact]
        public void ThenAllGoblinsGetTheRightColoursToolsAndJobs() =>
            employedGoblins
            .Should().BeEquivalentTo(new[]
            {
                new Goblin()
                {
                    Colour = Colour.Red,
                    Tools = new[] { new Pen() },
                    Job = "Writer",
                },
                new Goblin()
                {
                    Colour = Colour.Red,
                    Tools = new[] { new Pickaxe() },
                    Job = "Miner",
                },
                new Goblin()
                {
                    Colour = Colour.Blue,
                    Tools = new[] { new Pen() },
                    Job = "Rejected",
                },
                new Goblin()
                {
                    Colour = Colour.Green,
                    Tools = Array.Empty<ITool>(),
                    Job = "Writer",
                },
                new Goblin()
                {
                    Colour = Colour.Red,
                    Tools = new ITool[] { new Pen(), new Pickaxe() },
                    Job = "Miner"
                }
            }, 
                options => options.Excluding(goblin => goblin.Name));
    }
}
