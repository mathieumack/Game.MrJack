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

        public GameBoard()
            {
                //On remplie la table avec les cartes avec tueurs
                for (int i = 1; i < 3; i++)
                {
                    for( int j = 1; j < 3; j++)
                    {
                        Killers killer = new Killers();
                        Board[i, j] = new Card(killer);
                    }
                }
                //On place les detectives
                Board[0, 1] = new Card(Detectives.Sherlock);
                Board[4, 1] = new Card(Detectives.Watson);
                Board[2,4] = new Card(Detectives.Toby);
            }
            public int[,] swapPosition()
            {


                if (Action_ChangeCardPlace = true)
                {
                    //carte n°1
                    int x = Convert.ToInt32(Console.ReadLine());
                    int y = Convert.ToInt32(Console.ReadLine());
                    //carte n°2
                    int i = Convert.ToInt32(Console.ReadLine());
                    int j = Convert.ToInt32(Console.ReadLine());
                    //On échange la valeur des deux cartes
                    array[x, y] = array[i, j];
                    array[i, j] = array[x, y];
                }
                if (Action_SherlockMove = true)
                {

                }

                return array;
            }
    }
}
