namespace Goblins.Core
{
    public class GoblinEmploymentAgency
    {
        public IEnumerable<Goblin> Employ(IEnumerable<Goblin> goblins) => 
            goblins.Select(goblin =>
                {
                    goblin.Job = "Sitting Around";
                    return goblin;
                });
    }
}
