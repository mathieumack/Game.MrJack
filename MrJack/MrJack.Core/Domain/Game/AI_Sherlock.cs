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
       
        public AI_Sherlock(Randomizer rnd, IGame game) : base(rnd, game)
        {
            PlayerType = PlayerType.Sherlock;
        }
    }
}

