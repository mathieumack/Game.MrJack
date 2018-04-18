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
            this.actions = 1;
        }

        /// <summary>
        /// On détermine si le tour est pair ou impair
        /// </summary>
        /// <returns></returns>
        public bool IsDetectiveStart()
        {
            if (CurrentTurn % 2 == 0)
                return true;
            else
                return false;
        }

        /// <summary>
        /// Détermine le nb de jetons à piocher
        /// </summary>
        /// <returns></returns>
        public int NbJetonAPiocher()
        {
            if (actions == 1)
                return 1;
            else if (actions == 2)
                return 2;
            else if (actions == 3)
                return 1;
            else
                return 0;
        }

        /// <summary>
        /// On change de joueur pour l'action
        /// </summary>
        public void ChangeCurrentPlayer()
        {
            if (CurrentPlayer == PlayerType.MrJack)
            {
                CurrentPlayer = PlayerType.Sherlock;
            }
            else
            {
                CurrentPlayer = PlayerType.MrJack;
            }
        }

        /// <summary>
        /// Fin du tour
        /// </summary>
        public void End()
        {

        }

        /// <summary>
        /// On effectue les actions en fonction du type de jeton
        /// </summary>
       /* public void Action()
        {
            foreach(int i in Jetons)
            {
                if (i == 1)
                    ActionJetons.TournerCase();
                if (i == 2)
                    ActionJetons.DeplacerCase();
                if (i == 3)
                    ActionJetons.Sherlock();
                if (i == 4)
                    ActionJetons.Watson();
                if (i == 5)
                    ActionJetons.ChienToby();
                if (i == 6)
                    ActionJetons.Joker();
                if (i == 7)
                    ActionJetons.PiocherCarte();
            }
        }*/
    }
}
