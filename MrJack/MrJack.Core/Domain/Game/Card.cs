using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MrJack.Core.Domain.Game
{
    public class Card : ICard
    {
        Randomizer rnd { get; set; }
        public CardType CardType { get; set; }
        public Killers Killer { get; set; }
        public Detectives Detective { get; set; }
        public bool CanBeMoved { get { return CanBeMoved; } set { CanBeMoved = true; } }
        public bool Up { get; set; }
        public bool Right { get; set; }
        public bool Down { get; set; }
        public bool Left { get; set; }

        /// <summary>
        /// Card constructor
        /// </summary>
        /// <param name="cardType">The card type</param>
        private Card(CardType cardType, Randomizer rnd)
        {
            CardType = cardType;
            this.rnd = rnd;
        }

        /// <summary>
        /// The street card constructor
        /// </summary>
        /// <param name="killer">The name of the killer</param>
        public Card(Killers killer, Randomizer rnd) : this(CardType.Card, rnd)
        {
            Killer = killer;

            int nb = rnd.Next(1, 5);
            if (nb == 1)
            {
                Up = false;
                Right = true;
                Down = true;
                Left = true;
            }
            else if (nb == 2)
            {
                Up = true;
                Right = false;
                Down = true;
                Left = true;
            }
            else if (nb == 3)
            {
                Up = true;
                Right = true;
                Down = false;
                Left = true;
            }
            else
            {
                Up = true;
                Right = true;
                Down = true;
                Left = false;
            }
        }

        /// <summary>
        /// The token card constructor
        /// </summary>
        /// <param name="detective">The name of the detective</param>
        public Card(Detectives detective, Randomizer rnd) : this(CardType.Jeton, rnd)
        {
            Detective = detective;

            int nb = rnd.Next(1, 5);
            if (nb == 1)
            {
                Up = true;
                Right = false;
                Down = false;
                Left = false;
            }
            else if (nb == 2)
            {
                Up = false;
                Right = true;
                Down = false;
                Left = false;
            }
            else if (nb == 3)
            {
                Up = false;
                Right = false;
                Down = true;
                Left = false;
            }
            else
            {
                Up = false;
                Right = false;
                Down = false;
                Left = true;
            }
        }

        /// <summary>
        /// Turns over the street card
        /// </summary>
        public void Return()
        {
            if (Killer == Killers.Joseph_Lane)
            {
                Up = true;
                Right = true;
                Down = true;
                Left = true;
            }

            Killer = Killers.None;
        }

        /// <summary>
        /// Rotates the street card
        /// </summary>
        /// <param name="nb">How many turns</param>
        /// <exception cref="IndexOutOfRangeException">Please choose between 1 and 3</exception>
        public void Rotate(int nb)
        {
            if ((nb < 0) || (nb > 4))
                throw new IndexOutOfRangeException("Please choose between 1 and 3");
            bool temp = Up;
            Up = Left;
            Left = Down;
            Down = Right;
            Right = temp;

            if (nb > 1)
                Rotate(nb - 1);
        }

        /// <summary>
        /// Returns if the street card is open on that side
        /// </summary>
        /// <param name="direction">The direction wanted</param>
        public bool View(Direction direction)
        {
            if (direction.Equals(Direction.Up))
                return Up;
            else if (direction.Equals(Direction.Right))
                return Right;
            else if (direction.Equals(Direction.Down))
                return Down;
            else
                return Left;
        }

    }
}
