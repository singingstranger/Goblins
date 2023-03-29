using Goblins.Core;
using Goblins.Core.Tools;
using FluentAssertions;

namespace Goblins.Tests.UnitTests 
{
    public class WhenUsingEmploymentAgency 
    {
         [Fact]
        public void ThenRedPenGoblinsAreWriters() 
        {
            var employmentAgency = new GoblinEmploymentAgency();
            var goblin = new Goblin();
            goblin.Colour = Colour.Red;
            goblin.Tools = new [] {new Pen()};
            var goblinArray = new [] {goblin};

            var employedGoblins = employmentAgency.Employ(goblinArray);

            employedGoblins.Single().Job.Should().Be("Writer");
        }   

        [Fact]
        public void ThenRedPickaxeGoblinsAreMiners() 
        {
            var employmentAgency = new GoblinEmploymentAgency();
            var goblin = new Goblin();
            goblin.Colour = Colour.Red;
            goblin.Tools = new [] {new Pickaxe()};
            var goblinArray = new [] {goblin};

            var employedGoblins = employmentAgency.Employ(goblinArray);

            employedGoblins.Single().Job.Should().Be("Miner");
        }   
            //create Employment agency
            //pass in red pen goblin
            //assert correct job

        [Fact]
        public void ThenBlueGoblinsAreRejected()
        {
            var employmentAgency = new GoblinEmploymentAgency();
            var goblin = new Goblin();
            goblin.Colour = Colour.Blue;
            var goblinArray = new [] {goblin};

            var employedGoblins = employmentAgency.Employ(goblinArray);

            employedGoblins.Single().Job.Should().Be("Rejected");
        }

        [Fact]
        public void ThenAllGreenGoblinsGoToTheTower()
        {
            var employmentAgency = new GoblinEmploymentAgency();
            var goblin = new Goblin();
            goblin.Colour = Colour.Green;
            var goblinArray = new [] {goblin};

            var employedGoblins = employmentAgency.Employ(goblinArray);

            employedGoblins.Single().Job.Should().Be("Tower");
        }

        [Fact]
        public void ThenRedGoblinsWithoutToolsGoToTheTower()
        {
            var employmentAgency = new GoblinEmploymentAgency();
            var goblin = new Goblin();
            goblin.Colour = Colour.Red;
            var goblinArray = new [] {goblin};

            var employedGoblins = employmentAgency.Employ(goblinArray);

            employedGoblins.Single().Job.Should().Be("Tower");
        }

        [Fact]
        public void ThenRedGoblinsWithTwoToolsGetRejected()
        {
            var employmentAgency = new GoblinEmploymentAgency();
            var goblin = new Goblin();
            goblin.Colour = Colour.Red;
            goblin.Tools = new ITool[] {new Pickaxe(), new Pen()};
            var goblinArray = new [] {goblin};

            var employedGoblins = employmentAgency.Employ(goblinArray);

            employedGoblins.Single().Job.Should().Be("Rejected");
        }
    }
}