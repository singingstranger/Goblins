using FluentAssertions;
using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests.UnitTests
{
    public class WhenHatchingSingleGoblin
    {

        IEnumerable<Goblin> goblins = 
            new GoblinHatchery(
                new TestGoblinDataProvider(
                    new TestGoblinData(Colour.Red, Array.Empty<ITool>())))
            .Hatch();


        [Fact]
        public void ThenIGetOneGoblin() =>
            goblins.Should().NotBeEmpty();

        [Fact]
        public void ThenTheGoblinShouldHaveAName() =>
            goblins.Single().Name.Should().NotBeNullOrEmpty();
    }
}