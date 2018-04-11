using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class TokenAction
    {
        public Token Token1 { get; set; }
        public Token Token2 { get; set; }
        public Token Token3 { get; set; }
        public Token Token4 { get; set; }

        Random rnd = new Random();

        public TokenAction()
        {
            Token1 = new Token(ActionType.Joker);
            Token2 = new Token(ActionType.Move);
            Token3 = new Token(ActionType.Draw);
            Token3 = new Token(ActionType.Toby);
            Lancer();
        }

        /// <summary>
        /// If pour savoir quel jeton a quelle valeur
        /// </summary>
        public void Lancer()
        {
            int nb1 = rnd.Next(1, 3);
            if (nb1 == 1)
            {
                Token1 = new Token(ActionType.Joker);
            }
            else
            {
                Token1 = new Token(ActionType.Turn);
            }
            int nb2 = rnd.Next(1, 3);
            if (nb2 == 1)
            {
                Token2 = new Token(ActionType.Move);
            }
            else
            {
                Token2 = new Token(ActionType.Turn);
            }
            int nb3 = rnd.Next(1, 3);
            if (nb3 == 1)
            {
                Token3 = new Token(ActionType.Draw);
            }
            else
            {
                Token3 = new Token(ActionType.Sherlock);
            }
            int nb4 = rnd.Next(1, 3);
            if (nb4 == 1)
            {
                Token4 = new Token(ActionType.Toby);
            }
            else
            {
                Token4 = new Token(ActionType.Watson);
            }
        }
        /// <summary>
        /// if pour savoir quelles actions exécuter
        /// </summary>
        public void Tourner()
        {
            if (Token1.ActionType == ActionType.Joker)
            {
                Token1.ActionType = ActionType.Turn;
            }
            else
            {
                Token1.ActionType = ActionType.Joker;
            }

            if (Token2.ActionType == ActionType.Move)
            {
                Token2.ActionType = ActionType.Turn;
            }
            else
            {
                Token2.ActionType = ActionType.Move;
            }

            if (Token3.ActionType == ActionType.Draw)
            {
                Token3.ActionType = ActionType.Sherlock;
            }
            else
            {
                Token3.ActionType = ActionType.Draw;
            }

            if (Token4.ActionType == ActionType.Toby)
            {
                Token4.ActionType = ActionType.Watson;
            }
            else
            {
                Token4.ActionType = ActionType.Toby;
            }
        }
    }
}