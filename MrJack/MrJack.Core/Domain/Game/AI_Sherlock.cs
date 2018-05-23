using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_Sherlock : AI_MrJack_Easy
    {
       
        public AI_Sherlock(Randomizer rnd, IGame game) : base(rnd, game, PlayerType.Sherlock)
        { }

        public override void Joker(int actionIndex)
        {
            Detectives joker;
            bool moved = false;
            do
            {
                int nbjeton = Rnd.Next(1, 4);
                if (nbjeton == 1)
                {
                    joker = Detectives.Sherlock;
                }
                else if (nbjeton == 2)
                {
                    joker = Detectives.Watson;
                }
                else
                {
                    joker = Detectives.Toby;
                }

                int nb = 1;
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (GB.Board[i, j].Detective == joker && GB.Board[i, j].CanBeMoved)
                        {
                            Game.MoveDetective(actionIndex, i, j, nb);
                            moved = true;
                        }
                    }
                }
            }
            while (!moved);
        }
    }
}

