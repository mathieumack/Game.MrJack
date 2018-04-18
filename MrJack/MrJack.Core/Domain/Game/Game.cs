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
        public Turn Turn { get; set; }
        public Player Joueur { get; set; }
        public Randomizer Rnd { get; set; }
        public AI_MrJack_Easy IA { get; set; }
        /// <summary>
        /// Initialise variable when we create a game.
        /// </summary>
        /// <param name="typePlayer"></param>
        /// <param name="difficulty"></param>
        public void StartNewGame(PlayerType typePlayer, Difficulty difficulty)
        {
            Rnd = new Randomizer();
            Turn = new Turn();

            GameBoard = new GameBoard(Rnd);

            //New player with PlayerType
            Joueur = new Player(typePlayer);
            Draw mainDraw = new Draw();
            mainDraw.Pioche(Joueur.PlayerType, Rnd);

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
                if(difficulty == Difficulty.Easy)
                {
                    IA = new AI_MrJack_Easy(Killers.Insp_Lestrade, Rnd, this);
                }
                else if(difficulty == Difficulty.Medium)
                {
                    //Créer une IA de type PlayerType.MrJack et Moyenne
                }
                else
                {
                    //Créer une IA de type PlayerType.MrJack et Difficile
                }
            }
            MiddleGame();
        }

        /// <summary>
        /// Middle Game 
        /// </summary>  
        public void MiddleGame()
        {
            if(Turn.actions != 4)
            {
                Turn.CurrentPlayer = Turn.Whosplaying();

                Console.WriteLine("C'est au tour de " + Turn.CurrentPlayer.ToString());
                Console.WriteLine($"Nb de jetons sélectionnable: {Turn.NbJetonSelectionnable()}");

                if (IA.PlayerType == Turn.CurrentPlayer)
                {
                    Console.WriteLine("L'IA joue");
                    Turn.actions++;
                    IA.ChooseAction();
                }
                else
                {
                    Turn.actions++;
                }
            }
            else
            {
                Turn.CurrentTurn++;
            }    
        }

        public void TurnCard(int actionIndex, int x, int y, int nbTurn)
        {
            ICard card = GameBoard.Board[x, y];
            for (int i = 0; i < nbTurn; i++)
            {
                TurnCard(card);
                AvailableActions[actionIndex].Selectable = false;
            }
            this.MiddleGame();
        }

        }
             

        public void MoveCard(int actionIndex, int x1, int y1, int x2, int y2)
        {
            Move(x1, y1, x2, y2);
            AvailableActions[actionIndex].Selectable = false;
            this.MiddleGame();
        }

        private void Move(int x1, int y1, int x2, int y2)
        {
            ICard card1 = GameBoard.Board[x1, y1];
            ICard card2 = GameBoard.Board[x2, y2];

            GameBoard.Board[x1, y1] = card2;
            GameBoard.Board[x2, y2] = card1;

        }

        public Killers Draw(int actionIndex)
        {
            AvailableActions[actionIndex].Selectable = false;
            Draw draw = new Draw();
            Killers drawkiller = draw.Pioche(Joueur.PlayerType, Rnd);
            if(Joueur.PlayerType == PlayerType.Sherlock)
            {
                for (int i = 1; i <= 3; i++)
                {
                    for (int j = 1; j <= 3; j++)
                    {
                        if (GameBoard.Board[i, j].Killer == drawkiller)
                        {
                            GameBoard.Board[i, j].Return();
                        }
                    }
                }
            }
            else
            {
                Draw drawKiller = new Draw();
                drawKiller.killersSabliers.TryGetValue(drawkiller, out int sabliers);
                KillerPoints += sabliers;
            }
            return drawkiller;
        }

        public void MoveDetective(int actionIndex, int x1, int y1, int nbTurn)
        {
            int x = 0;
            int y = 0;
            int xFinal = x1;
            int yFinal = y1;
            for (int i = 1; i <= nbTurn; i++)
            {
                if (xFinal > yFinal)
                {
                    x = xFinal + yFinal < 4 && xFinal + yFinal > 0 ? xFinal + 1 : xFinal;
                    y = xFinal + yFinal < 8 && xFinal + yFinal > 4 ? yFinal + 1 : yFinal;

                    xFinal = x + y == 8 ? x - 1 : x;
                    yFinal = x + y == 4 && x == 4 ? y + 1 : y;
                }
                else if (xFinal < yFinal)
                {
                    x = xFinal + yFinal > 4 && xFinal + yFinal < 8 ? xFinal - 1 : xFinal;
                    y = xFinal + yFinal > 0 && xFinal + yFinal < 4 ? yFinal - 1 : yFinal;

                    xFinal = x + y == 0 ? x + 1 : x;
                    yFinal = x + y == 4 && x == 0 ? y - 1 : y;

                }
            }
            Move(x1, y1, xFinal, yFinal);
            AvailableActions[actionIndex].Selectable = false;
            this.MiddleGame();
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