using FluentAssertions;
using Goblins.Core;

namespace Goblins.Tests.UnitTests
{
    public class WhenHatchingSingleGoblin
    {

        IEnumerable<Goblin> goblins = 
            new GoblinHatchery(
                new TestGoblinDataProvider(
                    new TestGoblinData(Colour.Red, null)))
            .Hatch();


        [Fact]
        public void ThenIGetOneGoblin() =>
            goblins.Should().NotBeEmpty();

        [Fact]
        public void ThenTheGoblinShouldHaveAName() =>
            goblins.Single().Name.Should().NotBeNullOrEmpty();

        [Fact]
        public void ThenTheGoblinShouldBeUnemployed() =>
            goblins.Single().Job.Should().BeNullOrEmpty();
    }
}