using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_MrJack_Easy : Player
    {
        public Killers Killer { get; set; }
        public Random Rnd { get; set; }
        public IGame Game { get; set; }
<<<<<<< Updated upstream
        public IGameBoard GB { get; set; }
=======
        public GameBoard GB { get; set; }
>>>>>>> Stashed changes

        public AI_MrJack_Easy(Killers killer, Random rnd, IGame game) : base(PlayerType.MrJack)
        {
            Killer = killer;
            Rnd = rnd;
            Game = game;
            GB = Game.GameBoard;
        }
<<<<<<< Updated upstream
        
        /// <summary>
        /// Allows Mr Jack to do an action
        /// </summary>
        public void ChooseAction()
        {
            for(int actionIndex = 0; actionIndex < Game.AvailableActions.Count; actionIndex++)
            {
                if (Game.AvailableActions[actionIndex].Selectable)
                {
                    if(Game.AvailableActions[actionIndex].ActionType == ActionType.Draw)
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
=======

        public void ChooseAction()
        {
            for (int actionIndex = 0; actionIndex < Game.AvailableActions.Count; actionIndex++)
            {
                if (Game.AvailableActions[actionIndex].Selectable)
                {
                    if (Game.AvailableActions[actionIndex].ActionType == ActionType.Draw)
                    {

                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Joker)
                    {

                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Move)
                    {

>>>>>>> Stashed changes
                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Sherlock)
                    {
                        Sherlock(actionIndex);
                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Toby)
                    {
<<<<<<< Updated upstream
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


        /// <summary>
        /// Moves the Sherlock token
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Sherlock(int actionIndex)
        {
            int nb = Rnd.Next(1, 3);
            for(int i = 0; i <= 5; i++)
            {
                for(int j = 0; j <= 5; j++)
                {
                    if(GB.Board[i,j].Detective == Detectives.Sherlock)
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
        public void Watson(int actionIndex)
=======

                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Turn)
                    {

                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Watson)
                    {

                    }
                }

            }
        }

        public void Sherlock(int actionIndex)
>>>>>>> Stashed changes
        {
            int nb = Rnd.Next(1, 3);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
<<<<<<< Updated upstream
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
        public void Toby(int actionIndex)
        {
            int nb = Rnd.Next(1, 3);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
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
        public void Joker(int actionIndex)
        {
            Detectives joker;
            int nbjeton = Rnd.Next(1, 3);
            if(nbjeton == 1)
            {
                joker = Detectives.Sherlock;
            }
            else if (nbjeton == 2)
            {
                joker = Detectives.Watson;
            }
            else
            {
                joker = Detectives.Toby;
            }

            int nb = Rnd.Next(0, 2);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
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
=======
                    if (GB.Board[i, j].Detective == Detectives.Sherlock)
                    {
                        Game.MoveDetective(ActionIndex, i, j, nb);
                        Game.MoveDetective();
                    }
                }
            }

        }

        public void Watson()
        {
            int nb = Rnd.Next(1, 3);
            Game.Watson(nb);
        }

        public void Toby()
        {
            int nb = Rnd.Next(1, 3);
            Game.Toby(nb);
        }

        public void Joker()
        {
            int nb = Rnd.Next(0, 2);
            Game.Joker(nb);
        }

        public void Draw()
        {
            Game.Draw();
        }

        public void Move()
>>>>>>> Stashed changes
        {
            int x1 = Rnd.Next(1, 4);
            int y1 = Rnd.Next(1, 4);
            int x2 = Rnd.Next(1, 4);
            int y2 = Rnd.Next(1, 4);
<<<<<<< Updated upstream
            Game.MoveCard(actionIndex,x1, y1, x2, y2);
        }
        
        /// <summary>
        /// Turns the position of a card
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Turn(int actionIndex)
=======
            Game.MoveCard(x1, y1, x2, y2);
        }

        public void Turn()
>>>>>>> Stashed changes
        {
            int x = Rnd.Next(1, 4);
            int y = Rnd.Next(1, 4);
            int nb = Rnd.Next(1, 4);
<<<<<<< Updated upstream
            Game.TurnCard(actionIndex,x, y, nb);
=======
            Game.TurnCard(x, y, nb);
>>>>>>> Stashed changes
        }

    }
}
