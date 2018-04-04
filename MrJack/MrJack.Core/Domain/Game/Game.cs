using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrJack.Core.Domain.Game;

namespace MrJack.Core.Domain.Game
{
    class Game
    {
        public void start()
        {

            Turn turn = new Turn();

            if (turn.IsDetectiveStart())
            {
                turn.CurrentPlayer = PlayerType.Sherlock;
            }
            else
            {
                turn.CurrentPlayer = PlayerType.MrJack;
            }

            do
            {
                Console.WriteLine("C'est au tour de " + turn.CurrentPlayer);
                Console.WriteLine($"Nb de jetons à prendre: {turn.NbJetonAPiocher()}");
                actionEnCours(turn.NbJetonAPiocher());


                turn.actions++;
                turn.ChangeCurrentPlayer();
            } while (turn.actions <= 3);


            //turn.CurrentTurn++;
        }

        public static void actionEnCours(int nbAPiocher)
        {
            ActionType jeton = new ActionType();
            for (int i = 1; i <= nbAPiocher; i++)
            {
                Console.WriteLine("Voici les différentes actions:");
                Console.WriteLine("1 - Toby");
                Console.WriteLine("2 - Joker");
                Console.WriteLine("3 - Rotation");
                Console.WriteLine("4 - Move");
                Console.WriteLine("Que voulez-vous choisir ?");
                Console.ReadLine();
            }
        }
    }

    /*
     * Si tour impair   => on lance les jetons      => Le détective commence
     * Si tour pair     => on retourne les jetons   => Le criminel commence
     * on prend 1 jeton et on effectue son action
     * l'adversaire prend 2 jetons et effectue les actions
     * on prend le dernier jeton et on fait l'action
     * On regarde si les détectives ont repéré des suspects:
     *      -   Criminel non visible    => suspects visibles innocentés     => le criminel gagne un sablier
     *      -   Criminel visible        => suspects invisibles innocentés   => le détective gagne le jeton
     * On compte les sabliers du criminel
     */

    //TODO:Action Token
}

