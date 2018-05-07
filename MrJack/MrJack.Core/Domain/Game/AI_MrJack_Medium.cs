using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_MrJack_Medium : Base_IA
    {       
        private List<ActionType> orderedActions;

        public AI_MrJack_Medium(Randomizer rnd, IGame game, PlayerType playerType) : base(rnd, game, playerType)
        {            
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
        public override void ChooseAction()
        {
            bool notFound = true;
            bool finded = false;
            for (int j = 0; j < orderedActions.Count && notFound; j++)
            {
                for (int actionIndex = 0; actionIndex < Game.AvailableActions.Count && notFound && !finded; actionIndex++)
                {
                    if (Game.AvailableActions[actionIndex].Selectable &&
                        Game.AvailableActions[actionIndex].ActionType == orderedActions[j])
                    {
                        notFound = true;
                        if (Game.AvailableActions[actionIndex].ActionType == ActionType.Draw)
                        {
                            Draw(actionIndex);
                            finded = true;
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Joker)
                        {
                            Joker(actionIndex);
                            finded = true;
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Move)
                        {
                            Move(actionIndex);
                            finded = true;
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Sherlock)
                        {
                            Sherlock(actionIndex);
                            finded = true;
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Toby)
                        {
                            Toby(actionIndex);
                            finded = true;
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Turn)
                        {
                            Turn(actionIndex);
                            finded = true;
                        }
                        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Watson)
                        {
                            Watson(actionIndex);
                            finded = true;
                        }
                    }
                }
            }
        }

    }

}
