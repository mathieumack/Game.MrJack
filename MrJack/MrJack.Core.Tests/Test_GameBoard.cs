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
        public void Test_GameBoard_Init()
        {
            GameBoard Gb = new GameBoard();

            for (int i = 0; i < 5; i++)
            {
                for (int j = 0; j < 5; j++)
                {
                    Gb.Board[i,j]
                }
            }

            Assert.IsTrue(Gb.Board[0, 1].Detective == Detectives.Sherlock);
            Assert.IsTrue(Gb.Board[4, 1].Detective == Detectives.Watson);
            Assert.IsTrue(Gb.Board[2, 4].Detective == Detectives.Toby);
        }
    }
}
