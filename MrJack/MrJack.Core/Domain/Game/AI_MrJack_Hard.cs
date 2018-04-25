using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class AI_MrJack_Hard : Player, IIA
    {
        public Killers Killer { get; set; }
        public Randomizer Rnd { get; set; }
        public IGame Game { get; set; }
        public IGameBoard GB { get; set; }

        private List<ActionType> orderedActions;

        public AI_MrJack_Hard(Killers killer, Randomizer rnd, IGame game) : base(PlayerType.MrJack)
        {
            Killer = killer;
            Rnd = rnd;
            Game = game;
            GB = Game.GameBoard;

            orderedActions = new List<ActionType>()
            {
                ActionType.Draw,
                ActionType.Joker,
                ActionType.Move,
                ActionType.Turn,
                ActionType.Sherlock,
                ActionType.Toby,
                ActionType.Watson
            };
        }

        /// <summary>
        /// Allows Mr Jack to do an action
        /// </summary>
        public void ChooseAction()
        {
            bool notFound = true;
            for (int j = 0; j < orderedActions.Count && notFound; j++)
            {
                for (int actionIndex = 0; actionIndex < Game.AvailableActions.Count && notFound; actionIndex++)
                {
                    if (Game.AvailableActions[actionIndex].Selectable &&
                        Game.AvailableActions[actionIndex].ActionType == orderedActions[j])
                    {
                        notFound = true;
                        if (Game.AvailableActions[actionIndex].ActionType == ActionType.Draw)
                        {
                            Draw(actionIndex);
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Joker)
                        {
                            Joker(actionIndex);
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Move)
                        {
                            Move(actionIndex);
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Sherlock)
                        {
                            Sherlock(actionIndex);
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Toby)
                        {
                            Toby(actionIndex);
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Turn)
                        {
                            Turn(actionIndex);
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Watson)
                        {
                            Watson(actionIndex);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Moves the Sherlock token
        /// </summary>
        /// <param name="actionIndex">token number</param>
        /// <param name="nb">number of moves (1-2)</param>
        public void Sherlock(int actionIndex, int nb)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GB.Board[i, j].Detective == Detectives.Sherlock)
                    {
                        Game.MoveDetective(actionIndex, i, j, nb);
                    }
                }
            }
        }

        /// <summary>
        /// Moves the Watson token
        /// </summary>
        /// <param name="actionIndex">token number</param>
        /// <param name="nb">number of moves (1-2)</param>
        public void Watson(int actionIndex, int nb)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GB.Board[i, j].Detective == Detectives.Watson)
                    {
                        Game.MoveDetective(actionIndex, i, j, nb);
                    }
                }
            }
        }

        /// <summary>
        /// Moves the Toby token
        /// </summary>
        /// <param name="actionIndex">token number</param>   
        /// <param name="nb">number of moves (1-2)</param>
        public void Toby(int actionIndex, int nb)
        {
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GB.Board[i, j].Detective == Detectives.Toby)
                    {
                        Game.MoveDetective(actionIndex, i, j, nb);
                    }
                }
            }
        }

        /// <summary>
        /// Moves the any token
        /// </summary>
        /// <param name="actionIndex">token number</param>
        /// <param name="joker">the detective to move</param>
        /// <param name="nb">number of moves (0-1)</param>
        public void Joker(int actionIndex, Detectives joker, int nb)
        {            
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GB.Board[i, j].Detective == joker)
                    {
                        Game.MoveDetective(actionIndex, i, j, nb);
                    }
                }
            }
        }

        /// <summary>
        /// Draws a card
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Draw(int actionIndex)
        {
            Game.Draw(actionIndex);
        }

        /// <summary>
        /// Moves the position of two cards
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Move(int actionIndex)
        {
            int x1;
            int y1;
            do
            {
                x1 = Rnd.Next(1, 4);
                y1 = Rnd.Next(1, 4);
            }
            while (GB.Board[x1, y1].CanBeMoved);
            int x2;
            int y2;
            do
            {
                x2 = Rnd.Next(1, 4);
                y2 = Rnd.Next(1, 4);
            }
            while (GB.Board[x2, y2].CanBeMoved);
            Game.MoveCard(actionIndex, x1, y1, x2, y2);
        }

        /// <summary>
        /// Turns the position of a card
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Turn(int actionIndex)
        {
            int x;
            int y;
            do
            {
                x = Rnd.Next(1, 4);
                y = Rnd.Next(1, 4);
            }
            while (GB.Board[x, y].CanBeMoved);
            int nb = Rnd.Next(1, 4);
            Game.TurnCard(actionIndex, x, y, nb);
        }

        public List<Killers> CheckView()
        {
            List<Killers> visible = new List<Killers>();
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if(GB.Board[i,j].CardType == CardType.Jeton)
                    {
                        if (GB.Board[i, j].View(Direction.Down))
                        {
                            for(int k = 1; k < 4; k++)
                            {
                                if (GB.Board[i, k].View(Direction.Up)
                                    && GB.Board[i,k].Killer != Killers.None)
                                {
                                    visible.Add(GB.Board[i, k].Killer);
                                    if (!GB.Board[i, k].View(Direction.Down))
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
                        else if (GB.Board[i, j].View(Direction.Left))
                        {
                            for (int k = 3; k > 0; k--)
                            {
                                if (GB.Board[k, j].View(Direction.Right)
                                    && GB.Board[k, j].Killer != Killers.None)
                                {
                                    visible.Add(GB.Board[k, j].Killer);
                                    if (!GB.Board[k, j].View(Direction.Left))
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
                        else if (GB.Board[i, j].View(Direction.Right))
                        {
                            for (int k = 1; k < 4; k++)
                            {
                                if (GB.Board[k, j].View(Direction.Left)
                                    && GB.Board[k, j].Killer != Killers.None)
                                {
                                    visible.Add(GB.Board[k, j].Killer);
                                    if (!GB.Board[k, j].View(Direction.Right))
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
                        else if (GB.Board[i, j].View(Direction.Up))
                        {
                            for (int k = 3; k > 0; k--)
                            {
                                if (GB.Board[i, k].View(Direction.Down)
                                    && GB.Board[i, k].Killer != Killers.None)
                                {
                                    visible.Add(GB.Board[i, k].Killer);
                                    if (!GB.Board[i, k].View(Direction.Up))
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
            return visible;
        }

        public int KillerCount()
        {
            int nb = 0;
            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    if (GB.Board[i, j].CardType == CardType.Card &&
                        GB.Board[i, j].Killer != Killers.None)
                    {
                        nb++;
                    }
                }
            }
            return nb;
        }


        public void Choose()
        {            
            for (int actionIndex = 0; actionIndex < Game.AvailableActions.Count; actionIndex++)
            {
                if (Game.AvailableActions[actionIndex].Selectable)
                {
                    List<Killers> visible = CheckView();
                    int nbKillers = KillerCount();
                    if (nbKillers / 2 == visible.Count)
                    {
                        if (Game.KillerPoints > 4 || nbKillers > 5)
                        {
                            if(Game.AvailableActions[actionIndex].Selectable)
                            {
                                Draw(actionIndex);
                            }                                
                        }
                    }
                    else
                    {

                    }
                }
                
            }
        }
    }

}
