using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class TokenAction
    {
        public ActionType jeton1 {get ; set ;}
        public ActionType jeton2 { get; set; }
        public ActionType jeton3 { get; set; }
        public ActionType jeton4 { get; set; }

        Random rnd = new Random();
        
        /// <summary>
        /// If pour savoir quel jeton a quelle valeur
        /// </summary>
        public void Lancer()
        {
            int nb1 = rnd.Next(1, 3);
            if (nb1 == 1)
            {
                Token1 =  new Token(ActionType.Joker);
            }
            else
            {
                Token1 = new Token(ActionType.Turn);
            }
            int nb2 = rnd.Next(1, 3);
            if (nb2 == 2)
            {
                Token2 = new Token(ActionType.Move);
            }
            else
            {
                Token2 = new Token(ActionType.Turn);
            }
            int nb3 = rnd.Next(1, 3);
            if (nb3 == 3)
            {
                Token3 = new Token(ActionType.Draw);
            }
            else
            {
                Token3 = new Token(ActionType.Sherlock);
            }
            int nb4 = rnd.Next(1, 3);
            if (nb4 == 4)
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
            if (jeton1 == ActionType.Joker)
            {
                jeton1 = ActionType.Turn;
            }
            else
            {
                jeton1 = ActionType.Joker;
            }

            if (jeton2 == ActionType.Move)
            {
                jeton2 = ActionType.Turn;
            }
            else
            {
                jeton2 = ActionType.Move;
            }

            if (jeton3 == ActionType.Draw)
            {
                jeton3 = ActionType.Sherlock;
            }
            else
            {
                jeton3 = ActionType.Draw;
            }

            if (jeton4 == ActionType.Toby)
            {
                jeton4 = ActionType.Watson;
            }
            else
            {
                jeton4 = ActionType.Toby;
            }
        }
                
    }
}
