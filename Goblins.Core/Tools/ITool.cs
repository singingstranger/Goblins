using Goblins.Core.Items;

namespace Goblins.Core.Tools
{
    public interface ITool
    {
        void Action<T>(T item, Goblin actor)
            where T : Item;
    }
}

//every goblin has collection of tools and it's either a pen or a pickaxe