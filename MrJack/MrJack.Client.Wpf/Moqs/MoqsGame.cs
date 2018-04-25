using System.Collections.Generic;
using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;

namespace MrJack.Client.Wpf.Moqs
{
    public class MoqsGame : IGame
    {
        #region Properties

        public int CurrentTurn { get; set; }
        public int KillerPoints { get; set; }
        public int DetectivePoints { get; set; }
        public IGameBoard GameBoard { get; set; }
        public bool CanDraw { get; set; }
        public List<IAction> AvailableActions { get; set; }
        public List<Killers> UserDraw { get; set; }
        public string LastIAAction { get; set; }
        public bool EndTurnResult { get; set; }
        public Killers Killer { get; set; }

        #endregion

        #region Constructor

        public MoqsGame()
        {
            ConfigureMoq();
        }

        #endregion

        #region Properties

        public Killers Draw(int actionIndex)
        {
            throw new System.NotImplementedException();
        }

        public void MoveCard(int actionIndex, int x1, int y1, int x2, int y2)
        {
            throw new System.NotImplementedException();
        }

        public void StartNewGame(PlayerType typePlayer, Difficulty difficulty)
        {
            ConfigureMoq();
        }

        public void TurnCard(int actionIndex, int x, int y, int nbTurn)
        {
            throw new System.NotImplementedException();
        }

        public void MoveDetective(int actionIndex, int x, int y, int nbTurn)
        {

        }

        #endregion

        #region Private methods

        private void ConfigureMoq()
        {
            Killer = Killers.Madame;
            LastIAAction = "Custom IA Message";
            CurrentTurn = 5;
            KillerPoints = 3;
            DetectivePoints = 2;
            EndTurnResult = false;
            CanDraw = true;

            AvailableActions = new List<IAction>()
            {
                new MoqsAction() { ActionType = ActionType.Toby, Selectable = true },
                new MoqsAction() { ActionType = ActionType.Turn, Selectable = true },
                new MoqsAction() { ActionType = ActionType.Joker, Selectable = true },
                new MoqsAction() { ActionType = ActionType.Sherlock, Selectable = true },
            };

            GameBoard = new MoqsGameBoard();
        }

        Killers IGame.Draw(int actionIndex)
        {
            throw new System.NotImplementedException();
        }

        public void MiddleGame()
        {
            throw new System.NotImplementedException();
        }

        #endregion
    }
}
