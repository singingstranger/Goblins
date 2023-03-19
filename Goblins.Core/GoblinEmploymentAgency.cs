using Goblins.Core.Tools;

namespace Goblins.Core
{
    public class GoblinEmploymentAgency
    {
        public IEnumerable<Goblin> Employ(IEnumerable<Goblin> goblins) => 
            goblins.Select(goblin =>
                {
                    if (goblin.Colour == Colour.Blue){
                        goblin.Job = "Rejected";
                        return goblin;
                    }
                    if (goblin.Tools.OfType<Pickaxe>().Any())
                    {
                        goblin.Job = "Miner";   
                    }
                    else 
                    {
                        goblin.Job = "Writer";
                    }
                    
                    return goblin;
                });
    }
}
