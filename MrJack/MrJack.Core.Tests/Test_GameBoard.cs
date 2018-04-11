using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core.Domain.Game;

namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Test_GameBoard
    {
        [TestMethod]
        public void Test_GB_Init_nbOfCards()
        {
            GameBoard Gb = new GameBoard();
            int nb = 0;

            for (int i = 1; i < 3; i++)
            {
                for (int j = 1; j < 3; j++)
                {
                    Assert.IsTrue(Gb.Board[i, j].CardType == CardType.Card,  "Card : " + Gb.Board[i, j]);
                    nb++;
                }
            }

            Assert.IsTrue(nb == 9, "nombre of cards : " + nb);
        }

        [TestMethod]
        public void Test_GB_Init_Killers()
        {
            GameBoard Gb = new GameBoard();

            Assert.IsTrue(Gb.Board[0, 1].Detective == Detectives.Sherlock);
            Assert.IsTrue(Gb.Board[4, 1].Detective == Detectives.Watson);
            Assert.IsTrue(Gb.Board[2, 4].Detective == Detectives.Toby);
        }
    }
}
