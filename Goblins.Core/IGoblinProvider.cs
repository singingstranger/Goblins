using Goblins.Core.Tools;

namespace Goblins.Core
{
    public interface IGoblinProvider
    {
        int GetEggCount();
        Colour GetRandomGoblinColour();
        ITool? GetRandomTool();
    }
}