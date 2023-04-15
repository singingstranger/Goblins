namespace Goblins.Core
{
    public class GoblinReport
    {
        public int Count{get;}

        public Dictionary<Colour, int> CountByColour{get;}

        public GoblinReport(params EmployedGoblin[] employedGoblins)
        {
            Count = employedGoblins.Count();
            CountByColour = employedGoblins.ToDictionary(
                key => key.Goblin.Colour, 
                val => employedGoblins.Where
                    (employedGoblins => employedGoblins.Goblin.Colour==val.Goblin.Colour).Count());
        }
    }
}