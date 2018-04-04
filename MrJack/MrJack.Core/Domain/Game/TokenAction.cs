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
        /// If pour savoir qu'elle jeton a qu'elle valeur
        /// </summary>
        public void Lancer()
        {
            int nb1 = rnd.Next(1, 3);
            if (nb1 == 1)
            {
                jeton1 = ActionType.Joker;
            } else
            {
                jeton1 = ActionType.Turn;
            }
            int nb2 = rnd.Next(1, 3);
            if (nb2 == 2)
            {
                jeton2 = ActionType.Move;
            }
            else
            {
                jeton2 = ActionType.Turn;
            }
            int nb3 = rnd.Next(1, 3);
            if (nb3 == 3)
            {
                jeton3 = ActionType.Draw;
            }
            else
            {
                jeton3 = ActionType.Sherlock;
            }
            int nb4 = rnd.Next(1, 3);
            if (nb4 == 4)
            {
                jeton4 = ActionType.Toby;
            }
            else
            {
                jeton4 = ActionType.Watson;
            }
        } 
        /// <summary>
        /// if pour savoir qu'elles actions exécuter
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
        /// <summary>
        /// Méthode pour faire tourner la carte
        /// les execption sont là pour au cas ou le chiffre séléctionner soit trop grand, et si la carte choisit à été déplacé ou a déjà tourné.
        /// </summary>
        /// <param name="Card"></param>
        /// <param name="Rotation"></param>
        public void Turn(Card Card, int Rotation)
        {
            try
            {
            if (Card.CanBeMoved)
                {
                Card.Rotate(Rotation);
                } else
                {
                throw new Exception("Hello bitch you can't do this because the card has already been moved");
                }
            }catch
            {
                throw new IndexOutOfRangeException("Please choose between 1 and 3"); 
            }
        }
                
    }
}
