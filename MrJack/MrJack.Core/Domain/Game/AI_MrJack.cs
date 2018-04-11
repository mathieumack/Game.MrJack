using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_MrJack : Player
    {   
        public Killers Killer { get; set; }

        public AI_MrJack(PlayerType playerType, Killers killer) : base(playerType)
        {
            Killer = killer;

        }

    }
}
