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
        public GameBoard GB { get; set; }

        public AI_MrJack_Easy(Killers killer, Random rnd, IGame game) : base(PlayerType.MrJack)
        {
            Killer = killer;
            Rnd = rnd;
            Game = game;
            GB = Game.GameBoard;
        }
          
        public void ChooseAction()
        {
            for(int actionIndex = 0; actionIndex < Game.AvailableActions.Count; actionIndex++)
            {
                if (Game.AvailableActions[actionIndex].Selectable)
                {
                    if(Game.AvailableActions[actionIndex].ActionType == ActionType.Draw)
                    {

                    } else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Joker)
                    {

                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Move)
                    {

                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Sherlock)
                    {
                        Sherlock(actionIndex);
                    }
                    else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Toby)
                    {

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
        {
            int nb = Rnd.Next(1, 3);
            for(int i = 0; i <= 5; i++)
            {
                for(int j = 0; j <= 5; j++)
                {
                    if(GB.Board[i,j].Detective == Detectives.Sherlock)
                    {
                        Game.MoveDetective(i,j,nb,);
                        Game.MoveDetective()
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
        {
            int x1 = Rnd.Next(1, 4);
            int y1 = Rnd.Next(1, 4);
            int x2 = Rnd.Next(1, 4);
            int y2 = Rnd.Next(1, 4);
            Game.MoveCard(x1, y1, x2, y2);
        }

        public void Turn()
        {
            int x = Rnd.Next(1, 4);
            int y = Rnd.Next(1, 4);
            int nb = Rnd.Next(1, 4);
            Game.TurnCard(x, y, nb);
        }

    }
}
