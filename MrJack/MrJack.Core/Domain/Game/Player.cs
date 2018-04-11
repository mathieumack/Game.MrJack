using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class Player
    {
        public int nbSablier { get; set; }
        public PlayerType PlayerType { get; set; }

        public Player(PlayerType playerType) {
            nbSablier = 0;
            PlayerType = playerType;
        }
    }
}
