using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    class AI_MrJack_Hard : Base_IA
    {
        public Killers Killer { get; set; }
       
        private List<ActionType> orderedActions;

        public AI_MrJack_Hard(Killers killer, Randomizer rnd, IGame game, PlayerType playerType) : base(rnd, game, playerType)
        {
            Killer = killer;

            orderedActions = OrderActions();
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
        /// Moves the position of two cards
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Move(int actionIndex, int x1, int y1, int x2, int y2)
        {           
            Game.MoveCard(actionIndex, x1, y1, x2, y2);
        }

        /// <summary>
        /// Turns the position of a card
        /// </summary>
        /// <param name="actionIndex">token number</param>
        public void Turn(int actionIndex, int x, int y, int nb)
        {
            Game.TurnCard(actionIndex, x, y, nb);
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
        
        public List<ActionType> OrderActions()
        {
            List<ActionType> listAction = new List<ActionType>();
          
            List<Killers> visible = Game.CheckView();
            int nbKillers = KillerCount();
            if (nbKillers / 2 == visible.Count)
            {
                if (Game.KillerPoints > 4 || nbKillers > 5)
                {
                        listAction.Add(ActionType.Draw);                          
                }
            }
            else
            {

            }
            return listAction;
        }
    }

}

/**
 *   ActionType.Draw,
 *   ActionType.Joker,
 *   ActionType.Move,
 *   ActionType.Turn,
 *   ActionType.Sherlock,
 *   ActionType.Toby,                
 *   ActionType.Watso
 */