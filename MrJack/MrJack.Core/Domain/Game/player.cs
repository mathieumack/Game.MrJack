using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class Player
    {
        public int nbSablier { get; set; }
        /// <summary>
        /// Build Player
        /// </summary>
        Player()
        {
            nbSablier = 0;  
        }
    }
}