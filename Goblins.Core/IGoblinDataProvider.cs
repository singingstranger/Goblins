using Goblins.Core.Tools;

namespace Goblins.Core
{
    public interface IGoblinDataProvider
    {
        int GetEggCount();
        Colour GetColour(int index);
        ITool[] GetTools(int index);
    }
}