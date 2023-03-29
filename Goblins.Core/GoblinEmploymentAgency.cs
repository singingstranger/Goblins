using Goblins.Core.Tools;

namespace Goblins.Core
{
    public class GoblinEmploymentAgency
    {
            public IEnumerable <Goblin> Employ (IEnumerable<Goblin> goblins) //Behavior version of employing
            {
                int stoppedGoblins = 0;
                var miners = goblins
                    .Where(goblin=> goblin.Colour==Colour.Red)
                    .Where(goblin => goblin.Tools.OfType<Pickaxe>().Any())
                    .Where(goblin => goblin.Tools.Count() == 1);

                var writer = goblins
                    .Where(goblin => goblin.Colour==Colour.Red)
                    .Where(goblin => goblin.Tools.OfType<Pen>().Any())
                    .Where(goblin => goblin.Tools.Count() == 1);

                var rejects = goblins
                    .Where(goblin => goblin.Colour==Colour.Blue || goblin.Tools.Count() > 1);

                /*var towered = goblins
                    .Except(miners)
                    .Except(writer)
                    .Except(rejects);*/
                
                
                foreach (var goblin in goblins)
                {
                    if (miners.Contains(goblin)){
                        goblin.Job = "Miner";
                    }
                    else if (writer.Contains(goblin)){
                        goblin.Job = "Writer";
                    }
                    else if (rejects.Contains(goblin)){
                        goblin.Job = "Rejected";
                    }
                    else {
                        goblin.Job = "Tower";
                        stoppedGoblins++;
                    }
                    
                }

                return goblins;
            }

        private Goblin GiveJob(Goblin goblin, string jobTitle)
        {
            goblin.Job = jobTitle;
            return goblin;
        }
    }
}
