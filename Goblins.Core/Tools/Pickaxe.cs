using Goblins.Core.Items;

namespace Goblins.Core.Tools
{
    public class Pickaxe : ITool
    {
        public void Action<T>(T item, Goblin actor)
            where T : Item
        {
            if (item is Rock rock)
            {
                rock.Break();
            }
        }
    }
}
