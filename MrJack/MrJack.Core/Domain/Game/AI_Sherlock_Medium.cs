using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_Sherlock_Medium : AI_MrJack_Medium
    {
        public AI_Sherlock_Medium(Randomizer rnd, IGame game) : base(rnd, game)
        {
            PlayerType = PlayerType.Sherlock;

            orderedActions = new List<ActionType>()
            {
                ActionType.Sherlock,
                ActionType.Watson,
                ActionType.Toby,
                ActionType.Joker,
                ActionType.Turn,
                ActionType.Move,
                ActionType.Draw,
            };
        }
    }
}