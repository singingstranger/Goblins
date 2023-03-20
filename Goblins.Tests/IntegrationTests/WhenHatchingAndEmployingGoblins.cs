using FluentAssertions;
using Goblins.Core;
using Xunit.Abstractions;

namespace Goblins.Tests.IntegrationTests
{
    public class WhenHatchingAndEmployingGoblins
    {
        private IEnumerable<Goblin> employedGoblins;

        static TestGoblinProvider provider = new();

        public WhenHatchingAndEmployingGoblins(ITestOutputHelper outputHelper)
        {
            var hatchery = new GoblinHatchery(provider, outputHelper);
            
            var hatchedGoblins = hatchery.Hatch();

            employedGoblins = new GoblinEmploymentAgency()
                .Employ(hatchedGoblins);
        }

        [Fact]
        public void ThenAllGoblinsGetJobs_RegularMode()
        {
            foreach (var goblin in employedGoblins)
            {
                goblin.Job.Should().NotBeNullOrEmpty();
                goblin.Name.Should().NotBeNullOrEmpty();
            }
        }

        [Fact]
        public void ThenAllGoblinsGetJobs_FluentAllTheWayMode() =>
            employedGoblins.Should()
            .AllSatisfy(goblin =>
            {
                goblin.Job.Should().NotBeNullOrEmpty();
                goblin.Name.Should().NotBeNullOrEmpty();

            });
    }
}
