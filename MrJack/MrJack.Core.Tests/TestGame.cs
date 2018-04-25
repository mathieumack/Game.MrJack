using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;

namespace MrJack.Core.Tests
{
    [TestClass]
    public class TestGame
    {
        [TestMethod]
        public void TestMoveCard()
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 1;
            GameBoard gameBoard = new GameBoard(new Randomizer());
            ICard card1 = gameBoard.Board[x1, y1];
            ICard card2 = gameBoard.Board[x2, y2];

            gameBoard.Board[x1, y1] = card2;
            gameBoard.Board[x2, y2] = card1;

            Assert.IsTrue(card2 == gameBoard.Board[0, 0] && card1 == gameBoard.Board[0,1]);
        }

        public void TestDrawCard()
        {

        }
    }
}
