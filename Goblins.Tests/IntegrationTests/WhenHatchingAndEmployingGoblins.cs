﻿using FluentAssertions;
using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests.IntegrationTests
{
    public class WhenHatchingAndEmployingGoblins
    {
        private IEnumerable<EmployedGoblin> employedGoblins = 
            new GoblinEmploymentAgency()
                    .Employ(new GoblinHatchery(
                        new TestGoblinDataProvider(
                            new(Colour.Red, new[] { new Pen() }),
                            new(Colour.Red, new[] { new Pickaxe() }),
                            new(Colour.Blue, new[] { new Pen() }),
                            new(Colour.Green, Array.Empty<ITool>()),
                            new(Colour.Red, new ITool[] { new Pen(), new Pickaxe() })
                            ))
                        .Hatch());

        [Fact]
        public void ThenAllGoblinsGetJobs_FluentAllTheWayMode() =>
            employedGoblins
            .Should().AllSatisfy(goblin =>
            {
                goblin.Job.Should().NotBeNullOrEmpty();
                goblin.Goblin.Name.Should().NotBeNullOrEmpty();

            });

        [Fact]
        public void ThenAllGoblinsGetTheRightColoursToolsAndJobs() =>
            employedGoblins
            .Should().BeEquivalentTo(new[]
            {
                new EmployedGoblin()
                {
                    Goblin = new Goblin 
                    {
                        Colour = Colour.Red,
                        Tools = new[] { new Pen() },
                    },
                    Job = "Writer",
                },
                new EmployedGoblin()
                {
                    Goblin = new Goblin
                    {
                        Colour = Colour.Red,
                        Tools = new[] { new Pickaxe() },
                    },
                    Job = "Miner",
                },
                new EmployedGoblin()
                {
                    Goblin = new Goblin
                    {
                        Colour = Colour.Blue,
                        Tools = new[] { new Pen() },
                    },
                    Job = "Rejected",
                },
                new EmployedGoblin()
                {
                    Goblin = new Goblin
                    {
                        Colour = Colour.Green,
                        Tools = Array.Empty<ITool>(),
                    },
                    Job = "Tower",
                },
                new EmployedGoblin()
                {
                    Goblin = new Goblin
                    {
                        Colour = Colour.Red,
                        Tools = new ITool[] { new Pen(), new Pickaxe() },
                    },
                    Job = "Rejected"
                }
            }, 
            options => options.Excluding(goblin => goblin.Goblin.Name));
    }
}
