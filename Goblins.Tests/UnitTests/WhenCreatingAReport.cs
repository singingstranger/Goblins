using FluentAssertions;
using Goblins.Core;

namespace Goblins.Tests.UnitTests
{
    public class WhenCreatingAReport
    {
        //Arrange
        static EmployedGoblin[] employedGoblins = new [] {
            new EmployedGoblin(){
                Goblin = new Goblin(){
                    Colour = Colour.Red
                }
            },
            new EmployedGoblin(){
                Goblin = new Goblin(){
                    Colour = Colour.Green
                }
            },
            new EmployedGoblin(){
                Goblin = new Goblin(){
                    Colour = Colour.Blue
                }
            }
        };

        //Enact
        GoblinReport report = new GoblinReport(employedGoblins);

        //Assert
        [Fact]
        public void ThenNumberOfGoblinsIsDisplayed() => report.Count.Should().Be(employedGoblins.Count());

        [Fact]
        public void ThenNumberOfRedGoblinsIsDisplayed() => report.CountByColour[Colour.Red].Should().Be(1);

        [Fact]
        public void ThenNumberOfGreenGoblinsIsDisplayed() => report.CountByColour[Colour.Green].Should().Be(1);

        [Fact]
        public void ThenNumberOfBlueGoblinsIsDisplayed() => report.CountByColour[Colour.Blue].Should().Be(1);
    }
}
