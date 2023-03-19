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
        public void ThenRedPenGoblinsAreMiners() 
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
            
    }
}