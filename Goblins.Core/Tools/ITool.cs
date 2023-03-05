using Goblins.Core.Items;

namespace Goblins.Core.Tools
{
    public interface ITool
    {
        void Action<T>(T item, Goblin actor)
            where T : Item;
    }
}
