using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class Turn
    {
        public int CurrentTurn { get; set; } //Num du tour
        public int actions; //Numéro jeton utilisé
        public PlayerType CurrentPlayer;

        /// <summary>
        /// Programme principal
        /// </summary>
        public Turn()
        {
            this.CurrentTurn = 0;
            this.actions = -1;
        }

        /// <summary>
        /// On détermine si le tour est pair ou impair
        /// </summary>
        /// <returns></returns>
        public bool IsTurnPair()
        {
            if (CurrentTurn % 2 == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Détermine le nombre de jetons à piocher
        /// </summary>
        /// <returns>Retourne le nombre de jetons utilisables selon l'action</returns>
        public int NbJetonSelectionnable()
        {
            if (actions == 0)
                return 4;
            else if (actions == 1)
                return 3;
            else if (actions == 2)
                return 2;
            else if (actions == 3)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// Détermine quel joueur doit jouer selon l'action et si on est dans un tour pair ou impair
        /// </summary>
        /// <returns>Retourne le joueur qui doit jouer</returns>
        public PlayerType Whosplaying()
        {
            if(IsTurnPair())
            {
                if(actions == 0 || actions == 3)
                {
                    return PlayerType.Sherlock;
                }
                else
                {
                    return PlayerType.MrJack;
                }
            }
            else
            {
                if (actions == 0 || actions == 3)
                {
                    return PlayerType.MrJack;
                }
                else
                {
                    return PlayerType.Sherlock;
                }
            }
            
        }
      
        /// <summary>
        /// Fin du tour
        /// </summary>
        public void End()
        {

        }
     
    }
}
