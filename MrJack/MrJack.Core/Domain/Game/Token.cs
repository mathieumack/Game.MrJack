using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class Token : IAction
    {
        public ActionType ActionType { get; set; }
        public bool Selectable { get; set; }

        public Token(ActionType actionType)
        {
            ActionType = actionType;
            Selectable = true;
        }
    }
}
