﻿using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core.Domain.Game;
using MrJack.Core.Interfaces.Game;
using MrJack;
using System.Diagnostics.CodeAnalysis;

namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class TestGame
    {
       
        [TestMethod]
        public void TestMoveCard()
        {
            int x1 = 0;
            int y1 = 0;
            int x2 = 0;
            int y2 = 1;
            Game game = new Game();
            GameBoard gameBoard = new GameBoard(new Randomizer());
            ICard card1 = gameBoard.Board[x1, y1];
            ICard card2 = gameBoard.Board[x2, y2];

            gameBoard.Board[x1, y1] = card2;
            gameBoard.Board[x2, y2] = card1;

            Assert.IsTrue(card2 == gameBoard.Board[0, 0] && card1 == gameBoard.Board[0, 1]);
        }

        [TestMethod]
        public void TestDraw()
        {
            Draw draw = new Draw();
            Player Joueur;
            Randomizer Rnd;
            GameBoard gameBoard;


        }

        [TestMethod]
        public void TestTurnCard()
        {
            int x = 1;
            int y = 1;
            int nbTurn = 1;
            GameBoard gameBoard = new GameBoard(new Randomizer());
            ICard card = gameBoard.Board[x, y];
            card.Up = true;
            card.Right = false;
            card.Down = false;
            card.Left = false;
            card.Rotate(nbTurn);
            Assert.IsTrue(card.Up == false && card.Right == true && card.Down == false && card.Left == false);

            int x2 = 1;
            int y2 = 1;
            int nbTurn2 = 2;
            GameBoard gameBoard2 = new GameBoard(new Randomizer());
            ICard card2 = gameBoard2.Board[x, y];
            card2.Up = true;
            card2.Right = false;
            card2.Down = false;
            card2.Left = false;
            card2.Rotate(nbTurn2);

            Assert.IsTrue(card2.Up == false && card2.Right == false && card2.Down == true && card2.Left == false);
        }

        [TestMethod]
        public void TestMoveDetective()
        {
            Game game = new Game();
            PlayerType playerType = new PlayerType();
            Difficulty difficulty = new Difficulty();
            difficulty = Difficulty.Easy;
            playerType = PlayerType.Sherlock;           
            game.StartNewGame(playerType, difficulty);

            int x1 = 0;
            int y1 = 1;
            int nbTurn = 1;
            Assert.IsTrue(game.GameBoard.Board[x1, y1].Detective == Detectives.Sherlock);
            game.MoveDetective(0, x1, y1, nbTurn);
            Assert.IsTrue(game.GameBoard.Board[x1, y1].Detective == Detectives.None);
           

        }
        [TestMethod]
        public void test_Player()
        {
            Player player = new Player(PlayerType.MrJack);
            Assert.AreEqual(player.nbSablier, 0);
        }

        [TestMethod]
        public void Test_StartNewGame()
        {
            Game currentGame = new Game();
            Difficulty difficulty = Difficulty.Medium;
            currentGame.StartNewGame(PlayerType.Sherlock, difficulty);

            Assert.IsTrue(currentGame.IA is AI_Sherlock_Medium);
            
            currentGame.StartNewGame(PlayerType.MrJack, Difficulty.Hard);

        }
    }
}
