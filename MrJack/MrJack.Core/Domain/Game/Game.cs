using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;

namespace MrJack.Core.Domain.Game
{
    public class Game : IGame
    {
        public Killers Killer { get; set; }
        public int CurrentTurn { get; set; }
        public int KillerPoints { get; set; }
        public int DetectivePoints { get; set; }
        public IGameBoard GameBoard { get; set; }
        public bool CanDraw { get; set; }
        public List<IAction> AvailableActions { get; set; }
        public List<Killers> UserDraw { get; set; }
        public string LastIAAction { get; set; }
        public bool EndTurnResult { get; set; }
        private Turn turn { get; set; }
        public Player Joueur { get; set; }
       
        /// <summary>
        /// Initialise variable when we create a game.
        /// </summary>
        /// <param name="typePlayer"></param>
        /// <param name="difficulty"></param>
        public void StartNewGame(PlayerType typePlayer, Difficulty difficulty)
        {
            //New player with PlayerType
            Joueur = new Player(typePlayer);

            TokenAction tokenAction = new TokenAction();
            AvailableActions = new List<IAction>();
            AvailableActions.Add(tokenAction.Token1);
            AvailableActions.Add(tokenAction.Token2);
            AvailableActions.Add(tokenAction.Token3);
            AvailableActions.Add(tokenAction.Token4);

            //New IA with opposite of player and difficulty
            if (Joueur.PlayerType == PlayerType.MrJack)
            {
                //Créer une IA de type PlayerType.Sherlock
            }
            else
            {
                //Créer une IA de type PlayerType.MrJack
            }
            GameBoard = new GameBoard();
            Turn turn = new Turn();
            
        }

        /// <summary>
        /// Middle Game 
        /// </summary>
        public void MiddleGame()
        {
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

                turn.actions++;
                turn.ChangeCurrentPlayer();
            } while (turn.actions <= 3);


            //turn.CurrentTurn++;
        }

        public void TurnCard(int x, int y, int nbTurn)
        {

            throw new NotImplementedException();
        }

        public void MoveCard(int x1, int y1, int x2, int y2)
        {
            throw new NotImplementedException();
            
        }

        public void Draw()
        {
            throw new NotImplementedException();
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
}

