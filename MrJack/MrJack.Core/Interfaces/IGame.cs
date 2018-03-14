using MrJack.Core.Domain.Game;

namespace MrJack.Core.Interfaces
{
    public interface IGame
    {
        /// <summary>
        /// Start a new game
        /// </summary>
        /// <param name="typePlayer">Type of the huan player</param>
        void StartNewGame(PlayerType typePlayer);
    }
}
