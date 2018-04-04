using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class GameBoard
    {
            int[,] array = new int[5, 5];
            public int[,] fillArray()
            {
                //On remplie la table avec des valeurs de 0 à 24
                array[0, 0] = 0;
                array[0, 1] = 1;
                array[0, 2] = 2;
                array[0, 3] = 3;
                array[0, 4] = 4;
                array[1, 0] = 5;
                array[1, 1] = 6;
                array[1, 2] = 7;
                array[1, 3] = 8;
                array[1, 4] = 9;
                array[2, 0] = 10;
                array[2, 1] = 11;
                array[2, 2] = 12;
                array[2, 3] = 13;
                array[2, 4] = 14;
                array[3, 0] = 15;
                array[3, 1] = 16;
                array[3, 2] = 17;
                array[3, 3] = 18;
                array[3, 4] = 19;
                array[4, 0] = 20;
                array[4, 1] = 21;
                array[4, 2] = 22;
                array[4, 3] = 23;
                array[4, 4] = 24;
                return array;
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
