﻿using System;
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
        public TokenAction TokenAction { get; set; }
        public List<IAction> AvailableActions { get; set; }
        public List<Killers> UserDraw { get; set; }
        public string LastIAAction { get; set; }
        public bool EndTurnResult { get; set; }
        public Turn Turn { get; set; }
        public Player Joueur { get; set; }
        public Randomizer Rnd { get; set; }
        public IIA IA { get; set; }
        public Draw MainDraw { get; set; }

        /// <summary>
        /// Initialise les variables quand on crée une nouvelle partie.
        /// </summary>
        /// <param name="typePlayer">Type de joueur</param>
        /// <param name="difficulty">Difficulté de la partie</param>
        public void StartNewGame(PlayerType typePlayer, Difficulty difficulty)
        {
            Rnd = new Randomizer();
            Turn = new Turn();

            GameBoard = new GameBoard(Rnd);

            //New player with PlayerType
            Joueur = new Player(typePlayer);
            MainDraw = new Draw();
            Killer = MainDraw.Pioche(Rnd);
            KillerPoints = 0;
            DetectivePoints = 0;

            TokenAction = new TokenAction();
            AvailableActions = new List<IAction>();
            AvailableActions.Add(TokenAction.Token1);
            AvailableActions.Add(TokenAction.Token2);
            AvailableActions.Add(TokenAction.Token3);
            AvailableActions.Add(TokenAction.Token4);

            //New IA with opposite of player and difficulty
            if (Joueur.PlayerType == PlayerType.MrJack)
            {

                //Créer une IA de type PlayerType.Sherlock
                if (difficulty == Difficulty.Easy)
                {
                    IA = new AI_Sherlock(Rnd, this);
                }
                else if (difficulty == Difficulty.Medium)
                {
                    IA = new AI_Sherlock_Medium(Rnd, this);
                }
                else
                {
                    //Créer une IA de type PlayerType.MrJack et Difficile
                }
            }
            else
            {
                if(difficulty == Difficulty.Easy)
                {
                    IA = new AI_MrJack_Easy(Rnd, this, PlayerType.MrJack);
                }
                else if(difficulty == Difficulty.Medium)
                {
                    IA = new AI_MrJack_Medium(Rnd, this, PlayerType.MrJack);
                }
                else
                {
                    //Créer une IA de type PlayerType.MrJack et Difficile
                }
            }
            MiddleGame();
        }

        /// <summary>
        /// Middle Game permet de déterminer le milieu de la partie soit: 
        ///     - en ajoutant un tour, en changeant de joueur et en affichant ces informations sur la partie
        ///     - en terminant le tour si le tour est de 3
        /// </summary>  
        public void MiddleGame()
        {
            // fin de tour.
            if (Turn.actions == 3)
            {
                EndOfTurn();
            }
            else
            {
                Turn.actions++;

                Turn.CurrentPlayer = Turn.Whosplaying();

                Console.WriteLine("C'est au tour de " + Turn.CurrentPlayer.ToString());
                Console.WriteLine($"Nb de jetons sélectionnable: {Turn.NbJetonSelectionnable()}");

                //Si c'est au tour de l'IA
                if (Joueur.PlayerType != Turn.CurrentPlayer)
                {
                    Console.WriteLine("L'IA joue");
                    IA.ChooseAction();
                }
            }
        }

        /// <summary>
        /// Détermine la fin de la partie
        /// -> On ajoute un tour 
        /// -> On détermine l'action à -1
        /// -> On affiche tous les tueurs de la partie 
        /// </summary>
        public void EndOfTurn()
        {
            List<Killers> visible = CheckView();

            //Vérifie si le tuer est visible
            if (visible.Any(e => e == Killer))
            {
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (!visible.Any(e => e == GameBoard.Board[i, j].Killer))
                        {
                            GameBoard.Board[i, j].Return();
                        }
                    }
                }
                DetectivePoints++;
            }
            else
            {
                foreach (Killers killerVisible in visible)
                {
                    for (int i = 0; i < 5; i++)
                    {
                        for (int j = 0; j < 5; j++)
                        {
                            if (GameBoard.Board[i, j].Killer == killerVisible)
                            {
                                GameBoard.Board[i, j].Return();
                            }
                        }
                    }
                }
                KillerPoints++;
            }

            //Préparation pour le prochain tour
            Turn.CurrentTurn++;
            Turn.actions = -1;

            bool pair = Turn.IsTurnPair();
            if (pair)
                TokenAction.Lancer();
            else
                TokenAction.Tourner();
            AvailableActions.Clear();
            AvailableActions.Add(TokenAction.Token1);
            AvailableActions.Add(TokenAction.Token2);
            AvailableActions.Add(TokenAction.Token3);
            AvailableActions.Add(TokenAction.Token4);

            int nbkillers = 0;
            for (int i = 1; i <= 4; i++)
            {
                for (int j = 1; j <= 4; j++)
                {
                    GameBoard.Board[i, j].CanBeMoved = true;
                    if(GameBoard.Board[i,j].Killer != Killers.None)
                        nbkillers++;
                }
            }
            
            //Vérifie si c'est la fin de partie
            if(KillerPoints == 6)
            {
                Console.WriteLine("fini");
            }
            else if(Turn.CurrentTurn > 8)
            {
                Console.WriteLine("fini");
            }
            else if(nbkillers == 1)
            {
                Console.WriteLine("fini");
            }
            else
                MiddleGame();        
        }

        public void TurnCard(int actionIndex, int x, int y, int nbTurn)
        {
           ICard card = GameBoard.Board[x, y];

           card.Rotate(nbTurn);
           AvailableActions[actionIndex].Selectable = false;
           this.MiddleGame();
        }

        /// <summary>
        /// Permet d'intervertir deux cartes entre-elles en faisant appel à la fonction Move()
        /// </summary>
        /// <param name="actionIndex"></param>
        /// <param name="x1">Coordonnée x de la première carte à bouger</param>
        /// <param name="y1">Coordonnée y de la première carte à bouger</param>
        /// <param name="x2">Coordonnée x de la deuxième carte à bouger</param>
        /// <param name="y2">Coordonnée y de la deuxième carte à bouger</param>
        public void MoveCard(int actionIndex, int x1, int y1, int x2, int y2)
        {
            Move(x1, y1, x2, y2);
            GameBoard.Board[x1, y1].CanBeMoved = false;
            GameBoard.Board[x2, y2].CanBeMoved = false;
            AvailableActions[actionIndex].Selectable = false;
            this.MiddleGame();
        }

        /// <summary>
        /// Fonction qui bouge deux cartes dans le GameBoard
        /// </summary>
        /// <param name="x1">Coordonnée x de la première carte à bouger</param>
        /// <param name="y1">Coordonnée y de la première carte à bouger</param>
        /// <param name="x2">Coordonnée x de la deuxième carte à bouger</param>
        /// <param name="y2">Coordonnée y de la deuxième carte à bouger</param>
        private void Move(int x1, int y1, int x2, int y2)
        {
            ICard card1 = GameBoard.Board[x1, y1];
            ICard card2 = GameBoard.Board[x2, y2];

            GameBoard.Board[x1, y1] = card2;
            GameBoard.Board[x2, y2] = card1;            
        }

        /// <summary>
        /// Pioche un joueur dans la liste des killers
        /// </summary>
        /// <param name="actionIndex"></param>
        /// <returns></returns>
        public Killers Draw(int actionIndex)
        {
            Draw draw = new Draw();
            Killers drawkiller = draw.Pioche(Rnd);
            if(Turn.CurrentPlayer == PlayerType.Sherlock)
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
            AvailableActions[actionIndex].Selectable = false;
            this.MiddleGame();
            return drawkiller;
        }

        /// <summary>
        /// Déplace d'un certains de nombre de cases un détective
        /// </summary>
        /// <param name="actionIndex"></param>
        /// <param name="x1">Coordonnée x de la carte à déplacer</param>
        /// <param name="y1">Coordonnée y de la carte à déplacer</param>
        /// <param name="nbTurn">Nombre de cases de déplacement</param>
        public void MoveDetective(int actionIndex, int x1, int y1, int nbTurn)
        {
            int x = 0;
            int y = 0;
            int xFinal = x1;
            int yFinal = y1;
            bool rotate = false;
            for (int i = 1; i <= nbTurn; i++)
            {
                if (xFinal > yFinal)
                {
                    x = xFinal + yFinal < 4 && xFinal + yFinal > 0 ? xFinal + 1 : xFinal;
                    y = xFinal + yFinal < 8 && xFinal + yFinal > 4 ? yFinal + 1 : yFinal;

                    if (x + y == 8)
                    {
                        xFinal = x - 1;
                        rotate = true;
                    }
                    else
                        xFinal = x;

                    if (x + y == 4)
                    {
                        yFinal = y + 1;
                        rotate = true;
                    }
                    else
                        yFinal = y;
                }
                else if (xFinal < yFinal)
                {
                    x = xFinal + yFinal > 4 && xFinal + yFinal < 8 ? xFinal - 1 : xFinal;
                    y = xFinal + yFinal > 0 && xFinal + yFinal < 4 ? yFinal - 1 : yFinal;

                    if (x + y == 0)
                    {
                        xFinal = x + 1;
                        rotate = true;
                    }
                    else
                        xFinal = x;

                    if (x + y == 4)
                    {
                        yFinal = y - 1;
                        rotate = true;
                    }
                    else
                        yFinal = y;

                }
            }
            Move(x1, y1, xFinal, yFinal);
            if (rotate)
                GameBoard.Board[xFinal, yFinal].Rotate(1);
            GameBoard.Board[xFinal, yFinal].CanBeMoved = false;
            AvailableActions[actionIndex].Selectable = false;
            this.MiddleGame();
        }

        public List<Killers> CheckView()
        {
            List<Killers> visible = new List<Killers>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GameBoard.Board[i, j].Detective != Detectives.None)
                    {
                        if (GameBoard.Board[i, j].View(Direction.Down))
                        {
                            for (int k = 1; k < 4; k++)
                            {
                                if (GameBoard.Board[i, k].View(Direction.Up))
                                {
                                    visible.Add(GameBoard.Board[i, k].Killer);
                                    if (!GameBoard.Board[i, k].View(Direction.Down))
                                    {
                                        k = 4;
                                    }
                                }
                                else
                                {
                                    k = 4;
                                }
                            }
                        }
                        else if (GameBoard.Board[i, j].View(Direction.Left))
                        {
                            for (int k = 3; k > 0; k--)
                            {
                                if (GameBoard.Board[k, j].View(Direction.Right))
                                {
                                    visible.Add(GameBoard.Board[k, j].Killer);
                                    if (!GameBoard.Board[k, j].View(Direction.Left))
                                    {
                                        k = 0;
                                    }
                                }
                                else
                                {
                                    k = 0;
                                }
                            }
                        }
                        else if (GameBoard.Board[i, j].View(Direction.Right))
                        {
                            for (int k = 1; k < 4; k++)
                            {
                                if (GameBoard.Board[k, j].View(Direction.Left))
                                {
                                    visible.Add(GameBoard.Board[k, j].Killer);
                                    if (!GameBoard.Board[k, j].View(Direction.Right))
                                    {
                                        k = 4;
                                    }
                                }
                                else
                                {
                                    k = 4;
                                }
                            }
                        }
                        else if (GameBoard.Board[i, j].View(Direction.Up))
                        {
                            for (int k = 3; k > 0; k--)
                            {
                                if (GameBoard.Board[i, k].View(Direction.Down))
                                {
                                    visible.Add(GameBoard.Board[i, k].Killer);
                                    if (!GameBoard.Board[i, k].View(Direction.Up))
                                    {
                                        k = 0;
                                    }
                                }
                                else
                                {
                                    k = 0;
                                }
                            }
                        }
                    }
                }
            }

            visible.RemoveAll(Killers => Killers == Killers.None);

            return visible;
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