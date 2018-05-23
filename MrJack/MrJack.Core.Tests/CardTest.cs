using System;
using System.Text;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core.Domain.Game;
using System.Diagnostics.CodeAnalysis;

namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]

    public class CardTest
    {
        [TestMethod]
        public void Test_View_1()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Insp_Lestrade, rnd);
            card.Up = true;
            card.Left = true;
            card.Right = true;
            card.Down = false;

            bool up = card.View(Direction.Up);
            bool left = card.View(Direction.Left);
            bool right = card.View(Direction.Right);
            bool down = card.View(Direction.Down);

            Assert.IsTrue(up);
            Assert.IsTrue(left);
            Assert.IsTrue(right);
            Assert.IsFalse(down);
        }

        [TestMethod]
        public void Test_View_2()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Insp_Lestrade, rnd);
            card.Up = true;
            card.Left = false;
            card.Right = true;
            card.Down = true;

            bool up = card.View(Direction.Up);
            bool left = card.View(Direction.Left);
            bool right = card.View(Direction.Right);
            bool down = card.View(Direction.Down);

            Assert.IsTrue(up);
            Assert.IsFalse(left);
            Assert.IsTrue(right);
            Assert.IsTrue(down);
        }

        [TestMethod]
        public void Test_Rotate_1()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Insp_Lestrade, rnd);
            card.Up = true;
            card.Right = true;
            card.Down = false;
            card.Left = true;
            card.CanBeMoved = true;
                    
            card.Rotate(1);

            Assert.IsTrue(card.Up);
            Assert.IsTrue(card.Right);
            Assert.IsTrue(card.Down);
            Assert.IsFalse(card.Left);
            Assert.IsFalse(card.CanBeMoved);
        }

        [TestMethod]
        public void Test_Rotate_2()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Insp_Lestrade, rnd);
            card.Up = true;
            card.Right = true;
            card.Down = false;
            card.Left = true;
            card.CanBeMoved = true;

            card.Rotate(3);

            Assert.IsTrue(card.Up);
            Assert.IsFalse(card.Right);
            Assert.IsTrue(card.Down);
            Assert.IsTrue(card.Left);
            Assert.IsFalse(card.CanBeMoved);
        }

        [TestMethod]
        public void Test_Return()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Insp_Lestrade, rnd);
            card.Up = true;
            card.Right = true;
            card.Down = false;
            card.Left = true;

            card.Return();

            Assert.IsTrue(card.Killer == Killers.None);
            Assert.IsTrue(card.Up);
            Assert.IsTrue(card.Right);
            Assert.IsFalse(card.Down);
            Assert.IsTrue(card.Left);
        }

        [TestMethod]
        public void Test_Return_Joseph_Lane()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Joseph_Lane, rnd);
            card.Up = true;
            card.Right = true;
            card.Down = false;
            card.Left = true;

            card.Return();

            Assert.IsTrue(card.Killer == Killers.None);
            Assert.IsTrue(card.Up);
            Assert.IsTrue(card.Right);
            Assert.IsTrue(card.Down);
            Assert.IsTrue(card.Left);
        }

        [TestMethod]
        public void Test_Constructeur_Detective_Sherlock()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Detectives.Sherlock, rnd);
            
            Assert.IsTrue(card.Detective == Detectives.Sherlock);
            Assert.IsFalse(card.Up);
            Assert.IsTrue(card.Right);
            Assert.IsFalse(card.Down);
            Assert.IsFalse(card.Left);
            Assert.IsTrue(card.CanBeMoved);
        }

        [TestMethod]
        public void Test_Constructeur_Detective_Watson()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Detectives.Watson, rnd);

            Assert.IsTrue(card.Detective == Detectives.Watson);
            Assert.IsFalse(card.Up);
            Assert.IsFalse(card.Right);
            Assert.IsFalse(card.Down);
            Assert.IsTrue(card.Left);
            Assert.IsTrue(card.CanBeMoved);
        }

        [TestMethod]
        public void Test_Constructeur_Detective_Toby()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Detectives.Toby, rnd);

            Assert.IsTrue(card.Detective == Detectives.Toby);
            Assert.IsTrue(card.Up);
            Assert.IsFalse(card.Right);
            Assert.IsFalse(card.Down);
            Assert.IsFalse(card.Left);
            Assert.IsTrue(card.CanBeMoved);
        }

        [TestMethod]
        public void Test_Constructeur_Killers_Insp_Lestrade()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.Insp_Lestrade, rnd);

            Assert.IsTrue(card.Killer == Killers.Insp_Lestrade);

            if(card.Up == false)
            {
                Assert.IsFalse(card.Up);
                Assert.IsTrue(card.Right);
                Assert.IsTrue(card.Down);
                Assert.IsTrue(card.Left);
            }
            else if (card.Right == false)
            {
                Assert.IsTrue(card.Up);
                Assert.IsFalse(card.Right);
                Assert.IsTrue(card.Down);
                Assert.IsTrue(card.Left);
            }
            else if (card.Down == false)
            {
                Assert.IsTrue(card.Up);
                Assert.IsTrue(card.Right);
                Assert.IsFalse(card.Down);
                Assert.IsTrue(card.Left);
            }
            else if (card.Left == false)
            {
                Assert.IsTrue(card.Up);
                Assert.IsTrue(card.Right);
                Assert.IsTrue(card.Down);
                Assert.IsFalse(card.Left);
            }
            Assert.IsTrue(card.CanBeMoved);
        }

        [TestMethod]
        public void Test_Constructeur_Killers_John_Smith()
        {
            Randomizer rnd = new Randomizer();
            Card card = new Card(Killers.John_Smith, rnd);

            Assert.IsTrue(card.Killer == Killers.John_Smith);

            if (card.Up == false)
            {
                Assert.IsFalse(card.Up);
                Assert.IsTrue(card.Right);
                Assert.IsTrue(card.Down);
                Assert.IsTrue(card.Left);
            }
            else if (card.Right == false)
            {
                Assert.IsTrue(card.Up);
                Assert.IsFalse(card.Right);
                Assert.IsTrue(card.Down);
                Assert.IsTrue(card.Left);
            }
            else if (card.Down == false)
            {
                Assert.IsTrue(card.Up);
                Assert.IsTrue(card.Right);
                Assert.IsFalse(card.Down);
                Assert.IsTrue(card.Left);
            }
            else if (card.Left == false)
            {
                Assert.IsTrue(card.Up);
                Assert.IsTrue(card.Right);
                Assert.IsTrue(card.Down);
                Assert.IsFalse(card.Left);
            }
            Assert.IsTrue(card.CanBeMoved);
        }

    }
}
