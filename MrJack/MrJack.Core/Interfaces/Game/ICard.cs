using MrJack.Core.Domain.Game;

namespace MrJack.Core.Interfaces.Game
{
    public interface ICard
    {
        CardType CardType { get; set; }

        Killers Killer { get; set; }

        Detectives Detective { get; set; }

        bool CanBeMoved { get; set; }

        bool Up { get; set; }

        bool Down { get; set; }

        bool Left { get; set; }
        
        bool Right { get; set; }

        void Return();
        void Rotate(int nb);
        bool View(Direction direction);
    }
}
