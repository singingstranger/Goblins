﻿using FluentAssertions;
using Goblins.Core;
using Goblins.Core.Tools;

namespace Goblins.Tests.IntegrationTests
{
    public class WhenHatchingAndEmployingGoblins
    {
        private IEnumerable<Goblin> employedGoblins;

        public WhenHatchingAndEmployingGoblins() =>
            employedGoblins = new GoblinEmploymentAgency()
                .Employ(
                    new GoblinHatchery(
                        new TestGoblinProvider()
                        ).Hatch().ToList());

        [Fact]
        public void ThenAllGoblinsGetJobs() =>
            employedGoblins.Should().AllSatisfy(goblin => goblin.Job.Should().NotBeNullOrEmpty());
        
        [Fact]
        public void ThenAllRedPickaxeGoblinsAreMiners() =>
            employedGoblins
                .Where(goblin => goblin.Colour == Colour.Red)
                .Where(goblin => goblin.Tools.OfType<Pickaxe>().Any())
                .Should()
                .AllSatisfy(goblin => goblin.Job.Should().Be("Miner"));
        
        [Fact]
        public void ThenAllRedPenGoblinsAreWriters() =>
            employedGoblins
                .Where(goblin => goblin.Colour == Colour.Red)
                .Where(goblin => goblin.Tools.OfType<Pen>().Any())
                .Should()
                .AllSatisfy(goblin => goblin.Job.Should().Be("Writer"));
    }
}