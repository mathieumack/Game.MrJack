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
                //On remplie la table avec des valeurs de 0 à 24
                for (int i = 0; i < 5; i++)
                {
                    for( int j = 0; j < 5; j++)
                    {
                        Board[i, j] = new Card();
                    }
                }
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
