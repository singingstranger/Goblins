using Goblins.Core.Items;

namespace Goblins.Core.Tools
{
    public class Pen : ITool
    {
        public void Action<T>(T item, Goblin actor)
            where T : Item
        {
            if (item is Paper paper)
            {
                paper.Write($"{actor.Name} was here");
            }
        }
    }
}
