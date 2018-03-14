using MrJack.Core.Domain.Game;

namespace MrJack.Core.Interfaces.Game
{
    public interface IAction
    {
        ActionType ActionType { get; set; }

        bool Selectable { get; set; }
    }
}
