using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;
using System;

namespace MrJack.Client.Wpf.Moqs
{
    public class MoqsGameBoard : IGameBoard
    {
        public ICard[,] Board { get; set; }

        public MoqsGameBoard()
        {
            // We will build the game board :
            Board = new ICard[5, 5];

            // We fill the table :
            Board[0, 0] = CreateJeton(Detectives.None); // Line 0
            Board[0, 1] = CreateJeton(Detectives.None);
            Board[0, 2] = CreateJeton(Detectives.None);
            Board[0, 3] = CreateJeton(Detectives.None);
            Board[0, 4] = CreateJeton(Detectives.None);
            Board[1, 0] = CreateJeton(Detectives.Sherlock); // Line 1
            Board[1, 1] = CreateCard(Killers.Insp_Lestrade, true, true, true, false);
            Board[1, 2] = CreateCard(Killers.Jeremy_Bert, true, false, true, true);
            Board[1, 3] = CreateCard(Killers.John_Pizzer, true, true, true, false);
            Board[1, 4] = CreateJeton(Detectives.Watson);
            Board[2, 0] = CreateJeton(Detectives.None); // Line 2
            Board[2, 1] = CreateCard(Killers.John_Smith, true, true, true, true);
            Board[2, 2] = CreateCard(Killers.Joseph_Lane, true, false, true, true);
            Board[2, 3] = CreateCard(Killers.Madame, true, true, true, false);
            Board[2, 4] = CreateJeton(Detectives.None);
            Board[3, 0] = CreateJeton(Detectives.None); // Line 3
            Board[3, 1] = CreateCard(Killers.Miss_Stealthy, true, false, true, true);
            Board[3, 2] = CreateCard(Killers.Sgt_Goodley, false, true, true, true);
            Board[3, 3] = CreateCard(Killers.William_Gull, true, true, true, true);
            Board[3, 4] = CreateJeton(Detectives.None);
            Board[4, 0] = CreateJeton(Detectives.None); // Line 4
            Board[4, 1] = CreateJeton(Detectives.None);
            Board[4, 2] = CreateJeton(Detectives.Toby);
            Board[4, 3] = CreateJeton(Detectives.None);
            Board[4, 4] = CreateJeton(Detectives.None);
        }

        private ICard CreateJeton(Detectives detective)
        {
            return new MoqsCard() { CardType = CardType.Jeton, Detective = detective };
        }

        private ICard CreateCard(Killers killer, bool left, bool up, bool right, bool down)
        {
            return new MoqsCard() { CardType = CardType.Card,
                                        Killer = killer,
                                        Left = left,
                                        Up = up,
                                        Right = right,
                                        Down = down
            };
        }
    }
}
