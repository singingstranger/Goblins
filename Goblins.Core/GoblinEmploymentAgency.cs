using Goblins.Core.Tools;

namespace Goblins.Core
{
    public class GoblinEmploymentAgency
    {
        public IEnumerable <EmployedGoblin> Employ (IEnumerable<Goblin> goblins) //Behavior version of employing
        {

            var rejects = goblins
                .Where(BlueGoblins)
                .Union(goblins
                    .Where(RedGoblins)
                    .Where(WithTwoTools));

            var miners = goblins
                .Except(rejects)
                .Where(RedGoblins)
                .Where(WithPickaxes)
                .Where(WithSingleTool);

            var writer = goblins
                .Except(rejects)
                .Where(RedGoblins)
                .Where(WithPens)
                .Where(WithSingleTool);

            var guards = goblins
                .Except(rejects)
                .Where(GreenGoblins)
                .Union(goblins
                    .Where(RedGoblins)
                    .Where(WithNoTools));

            return miners
                .Select(g => EmployGoblin(g, "Miner"))
                .Union(writer
                    .Select(g => EmployGoblin(g, "Writer")))
                .Union(guards
                    .Select(g => EmployGoblin(g, "Tower")))
                .Union(rejects
                    .Select(g => EmployGoblin(g, "Rejected")));
        }

        private static bool RedGoblins(Goblin goblin) => 
            goblin.Colour == Colour.Red;

        private static bool GreenGoblins(Goblin goblin) =>
            goblin.Colour == Colour.Green;

        private static bool BlueGoblins(Goblin goblin) =>
            goblin.Colour == Colour.Blue;

        private static bool WithPickaxes(Goblin goblin) =>
            goblin.Tools.OfType<Pickaxe>().Any();

        private static bool WithPens(Goblin goblin) =>
            goblin.Tools.OfType<Pen>().Any();

        private static bool WithSingleTool(Goblin goblin) =>
            goblin.Tools.Count() == 1;

        private static bool WithTwoTools(Goblin goblin) =>
            goblin.Tools.Count() == 2;

        private static bool WithNoTools(Goblin goblin) =>
            !goblin.Tools.Any();

        private static EmployedGoblin EmployGoblin(Goblin g, string job) => 
            new EmployedGoblin() { Goblin = g, Job = job };
    }
}
