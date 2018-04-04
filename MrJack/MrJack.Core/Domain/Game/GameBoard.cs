using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class GameBoard : IGameBoard
    {
        public ICard[,] Board { get; set; }

        /// <summary>
        /// Creates the board game
        /// </summary>
        public GameBoard()
        {
            Draw listeKillers = new Draw();
            //On remplie la table avec les cartes avec tueurs
            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    Killers killer = listeKillers.Pioche(PlayerType.Sherlock);
                    Board[i, j] = new Card(killer);
                }
            }
            //On place les detectives
            Board[0, 1] = new Card(Detectives.Sherlock);
            Board[4, 1] = new Card(Detectives.Watson);
            Board[2, 4] = new Card(Detectives.Toby);
        }
    }  

}
