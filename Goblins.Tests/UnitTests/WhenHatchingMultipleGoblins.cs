using FluentAssertions;
using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests.UnitTests
{
    public class WhenHatchingMultipleGoblins
    {
        const int GoblinCount = 100;
        const Colour GoblinColour = Colour.Blue;
        static Pen GoblinTool = new();

        IEnumerable<Goblin> goblins = 
            new GoblinHatchery(
                new TestGoblinDataProvider(
                    Enumerable
                        .Range(0, GoblinCount)
                        .Select(i => new TestGoblinData(GoblinColour, new[] { GoblinTool })
                    ).ToArray()))
            .Hatch();

        [Fact]
        public void ThenIShouldHaveTheRightNumberOfGoblins() =>
            goblins.Count().Should().Be(GoblinCount);

        [Fact]
        public void ThenTheyAllHaveUniqueNames() =>
            goblins.Select(goblin => goblin.Name)
                .Should().OnlyHaveUniqueItems();

        [Fact]
        public void ThenTheyAllShouldHaveTheSameColour() =>
            goblins
                .Should().AllSatisfy(goblin => goblin.Colour.Should().Be(GoblinColour));
    }
}