using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;

namespace MrJack.Client.Wpf.Moqs
{
    public class MoqsCard : ICard
    {
        public CardType CardType { get; set; }
        public Killers Killer { get; set; }
        public Detectives Detective { get; set; }
        public bool CanBeMoved { get; set; }
        public bool Up { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }
        public bool Right { get; set; }

        public ICard Killers => throw new System.NotImplementedException();
    }
}
