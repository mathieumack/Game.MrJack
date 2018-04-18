using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core.Domain.Game;
using System.Linq;

namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Test_GameBoard
    {
        [TestMethod]
        public void Test_GB_nbOfCards()
        {
            Randomizer rnd = new Randomizer();
            GameBoard Gb = new GameBoard(rnd);
            int nb = 0;

            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Assert.IsTrue(Gb.Board[i, j].CardType == CardType.Card,  "Card : " + Gb.Board[i, j].CardType);
                    nb++;
                }
            }

            Assert.IsTrue(nb == 9, "nombre of cards : " + nb);
        }
        
        [TestMethod]
        public void Test_GB_Killers()
        {
            Randomizer rnd = new Randomizer();
            GameBoard Gb = new GameBoard(rnd);
            List<Killers> ListKillers = new List<Killers>();
            ListKillers.Add(Killers.William_Gull);
            ListKillers.Add(Killers.John_Smith);
            ListKillers.Add(Killers.Jeremy_Bert);
            ListKillers.Add(Killers.Joseph_Lane);
            ListKillers.Add(Killers.Miss_Stealthy);
            ListKillers.Add(Killers.Insp_Lestrade);
            ListKillers.Add(Killers.Sgt_Goodley);
            ListKillers.Add(Killers.Madame);
            ListKillers.Add(Killers.John_Pizzer);


            for (int i = 1; i <= 3; i++)
            {
                for (int j = 1; j <= 3; j++)
                {
                    Assert.IsTrue(ListKillers.Any(e => e == Gb.Board[i, j].Killer) , "Card : " + Gb.Board[i, j].Killer);
                    ListKillers.Remove(Gb.Board[i, j].Killer);
                }
            }
        }

        [TestMethod]
        public void Test_GB_Detectives()
        {
            Randomizer rnd = new Randomizer();
            GameBoard Gb = new GameBoard(rnd);

            Assert.IsTrue(Gb.Board[0, 1].Detective == Detectives.Sherlock);
            Assert.IsTrue(Gb.Board[4, 1].Detective == Detectives.Watson);
            Assert.IsTrue(Gb.Board[2, 4].Detective == Detectives.Toby);
        }
    }
}
