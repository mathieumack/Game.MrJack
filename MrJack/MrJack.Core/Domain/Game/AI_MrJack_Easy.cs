using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class AI_MrJack_Easy : Base_IA
    {
        public AI_MrJack_Easy(Randomizer rnd, IGame game, PlayerType playerType) : base(rnd, game, playerType)
        { }

        /// <summary>
        /// Allows Mr Jack to do an action
        /// </summary>
        public override void ChooseAction()
        {
            bool finded = false;
            for (int actionIndex = 0; actionIndex < Game.AvailableActions.Count && !finded; actionIndex++)
            {
                if (Game.AvailableActions[actionIndex].Selectable)
                {
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
