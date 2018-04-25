using MrJack.Core.Domain.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Interfaces.Game
{
    public interface IIA
    {
        Killers Killer { get; set; }
        Randomizer Rnd { get; set; }
        IGame Game { get; set; }
        IGameBoard GB { get; set; }

        void ChooseAction();
    }
}