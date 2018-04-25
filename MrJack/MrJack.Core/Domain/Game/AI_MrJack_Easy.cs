using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_MrJack_Easy : Player, IIA
    {
        public Killers Killer { get; set; }
        public Randomizer Rnd { get; set; }
        public IGame Game { get; set; }
        public IGameBoard GB { get; set; }

        public AI_MrJack_Easy(Killers killer, Randomizer rnd, IGame game) : base(PlayerType.MrJack)
        {
            Killer = killer;
            Rnd = rnd;
            Game = game;
            GB = Game.GameBoard;
        }
        
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


        /// <summary>
        /// Moves the Sherlock token
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Sherlock(int actionIndex)
        {
            int nb = Rnd.Next(1, 3);
            for(int i = 0; i < 5; i++)
            {
                for(int j = 0; j < 5; j++)
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
        {
            int nb = Rnd.Next(1, 3);
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
        public void Toby(int actionIndex)
        {
            int nb = Rnd.Next(1, 3);
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
        public void Joker(int actionIndex)
        {
            Detectives joker;
            bool moved = false;
            do
            {
                int nbjeton = Rnd.Next(1, 3);
                if (nbjeton == 1)
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
                for (int i = 0; i < 5; i++)
                {
                    for (int j = 0; j < 5; j++)
                    {
                        if (GB.Board[i, j].Detective == joker && GB.Board[i,j].CanBeMoved)
                        {
                            Game.MoveDetective(actionIndex, i, j, nb);
                            moved = true;
                        }
                    }
                }
            }
            while (!moved);
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
            Game.TurnCard(actionIndex,x, y, nb);
        }

    }
}
