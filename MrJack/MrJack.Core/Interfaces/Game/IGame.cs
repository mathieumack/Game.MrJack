using MrJack.Core.Domain.Game;
using System.Collections.Generic;

namespace MrJack.Core.Interfaces.Game
{
    public interface IGame
    {
        /// <summary>
        /// Current killer for this game
        /// </summary>
        Killers Killer { get; set; }

        /// <summary>
        /// Get the current turn
        /// </summary>
        int CurrentTurn { get; set; }

        /// <summary>
        /// Points for the killer
        /// </summary>
        int KillerPoints { get; set; }

        /// <summary>
        /// Points for the detective
        /// </summary>
        int DetectivePoints { get; set; }

        /// <summary>
        /// Current game board
        /// </summary>
        IGameBoard GameBoard { get; set; }

        /// <summary>
        /// Define if we must enable the draw
        /// </summary>
        bool CanDraw { get; set; }

        /// <summary>
        /// List of 4 available actions
        /// </summary>
        List<IAction> AvailableActions { get; set; }

        /// <summary>
        /// Current user draw
        /// </summary>
        List<Killers> UserDraw { get; set; }

        Draw MainDraw { get; set; }

        /// <summary>
        /// Lest IA action message
        /// </summary>
        string LastIAAction { get; set; }

        /// <summary>
        /// True if the killer is visible
        /// </summary>
        bool EndTurnResult { get; set; }
        

        /// <summary>
        /// Start a new game
        /// </summary>
        /// <param name="typePlayer">Type of the human player</param>
        /// <param name="difficulty">easy, medium, hard, ...</param>
        void StartNewGame(PlayerType typePlayer, Difficulty difficulty);

        /// <summary>
        /// Action called when we turn a card
        /// </summary>
        /// <param name="actionIndex"></param>
        /// <param name="x">Column</param>
        /// <param name="y">Line</param>
        /// <param name="nbTurn"></param>
        void TurnCard(int actionIndex, int x, int y, int nbTurn);

        /// <summary>
        /// Action called when we move a detective
        /// </summary>
        /// <param name="actionIndex"></param>
        /// <param name="x">Column</param>
        /// <param name="y">Line</param>
        /// <param name="nbTurn"></param>
        void MoveDetective(int actionIndex, int x, int y, int nbTurn);

        /// <summary>
        /// Move 2 cards
        /// </summary>
        /// <param name="actionIndex"></param>
        /// <param name="x1"></param>
        /// <param name="y1"></param>
        /// <param name="x2"></param>
        /// <param name="y2"></param>
        void MoveCard(int actionIndex, int x1, int y1, int x2, int y2);

        /// <summary>
        /// Pick a card on the draw
        /// </summary>
        /// <param name="actionIndex"></param>
        Killers Draw(int actionIndex);
        void MiddleGame();
        /// <summary>
        /// The list of killers visible by the dectives
        /// </summary>
        /// <returns></returns>
        List<Killers> CheckView();
    }
}
