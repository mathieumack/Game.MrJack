using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MrJack.Core.Domain.Game;


namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestTurn
    {
        [TestMethod]
        public void TestIsTurnPair()
        {
            Turn turn = new Turn();
            turn.CurrentTurn = 0;
            Assert.IsTrue(turn.IsTurnPair() == true);

            turn.CurrentTurn = 1;
            Assert.IsTrue(turn.IsTurnPair() == false);
        }

        [TestMethod]
        public void TestNbJetonsSelectionnable()
        {
            Turn turn = new Turn();
            turn.actions = 0;
            Assert.IsTrue(turn.NbJetonSelectionnable() == 4);

            turn.actions = 1;
            Assert.IsTrue(turn.NbJetonSelectionnable() == 3);

            turn.actions = 2;
            Assert.IsTrue(turn.NbJetonSelectionnable() == 2);

            turn.actions = 3;
            Assert.IsTrue(turn.NbJetonSelectionnable() == 1);

            turn.actions = 4;
            Assert.IsTrue(turn.NbJetonSelectionnable() == 0);
        }

        [TestMethod]
        public void TestWhosplaying()
        {
            Turn turn = new Turn();
            turn.CurrentTurn = 0;
            turn.actions = 0;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.Sherlock);

            turn.CurrentTurn = 0;
            turn.actions = 3;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.Sherlock);

            turn.actions = 1;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.MrJack);
            turn.actions = 2;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.MrJack);
            turn.actions = 4;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.MrJack);

            turn.CurrentTurn = 1;
            turn.actions = 0;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.MrJack);

            turn.CurrentTurn = 1;
            turn.actions = 3;
            Assert.IsTrue(turn.Whosplaying() == PlayerType.MrJack);
        }
    }
}
