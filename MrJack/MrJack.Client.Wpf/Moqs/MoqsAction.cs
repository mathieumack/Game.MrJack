using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;
using System;

namespace MrJack.Client.Wpf.Moqs
{
    public class MoqsAction : IAction
    {
        public ActionType ActionType { get; set; }
        public bool Selectable { get; set; }
    }
}
