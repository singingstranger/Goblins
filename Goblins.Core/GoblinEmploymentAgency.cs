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
                    }
                    else if (goblin.Colour == Colour.Red)
                    {
                        if (goblin.Tools.OfType<Pickaxe>().Any())
                        {
                            goblin.Job = "Miner";   
                        }
                        else if (goblin.Tools.Any())
                        {
                            goblin.Job = "Writer";
                        }
                        else 
                        {
                            goblin.Job = "Tower";
                        }
                        
                    }
                    else 
                    {
                        goblin.Job = "Tower";
                    }
                    
                    return goblin;
                });
    }
}
