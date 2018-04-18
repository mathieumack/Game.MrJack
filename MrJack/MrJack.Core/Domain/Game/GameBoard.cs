using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class GameBoard : IGameBoard
    {
        public ICard[,] Board { get; set; }

        /// <summary>
        /// Creates the board game
        /// </summary>
        public GameBoard(Randomizer Rnd)
        {
            Board = new ICard[5,5];
            Draw listeKillers = new Draw();
           

            //On remple tous le tableau avec des dectivies vide
            for (int k = 0; k <= 4; k++)
            {
                for (int l = 0; l <= 4; l++)
                {
                    Board[k, l] = new Card(Detectives.None, Rnd);
                }
            }

            //On remplie la table avec les cartes avec tueurs
            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Killers killer = listeKillers.Pioche(PlayerType.Sherlock, Rnd);
                    Board[i, j] = new Card(killer, Rnd);
                }
            }

            //On place les detectives
            Board[0, 1] = new Card(Detectives.Sherlock, Rnd);
            Board[4, 1] = new Card(Detectives.Watson, Rnd);
            Board[2, 4] = new Card(Detectives.Toby, Rnd);
        }
    }  

}
