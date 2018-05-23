using MrJack.Core.Interfaces.Game;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core.Domain.Game;
using System.Linq;

namespace MrJack.Core.Tests
{
    /// <summary>
    /// Description résumée pour Test_AISherlock
    /// </summary>
    [TestClass]
    [ExcludeFromCodeCoverage]

    public class Test_AISherlock
    {
        public Detectives Detectives { get; set; }
        public Random Rnd { get; set; }
        public Randomizer Rndz { get; set; }
        public IGame Game { get; set; }
        public IGameBoard GB { get; set; }
        //arrange
        public void Test_Create_Detectives(Detectives detectives, Random rnd, IGame game)
        {
            //
            // TODO: ajoutez ici la logique du constructeur
            //
            Assert.IsTrue(detectives == Detectives);
            Assert.IsTrue(Rnd == rnd);
            Assert.IsNotNull(Game = game);
            Assert.IsNotNull(GB = Game.GameBoard);
        }

        private TestContext testContextInstance;

        /// <summary>
        ///Obtient ou définit le contexte de test qui fournit
        ///des informations sur la série de tests active, ainsi que ses fonctionnalités.
        ///</summary>
        public TestContext TestContext
        {
            get
            {
                return testContextInstance;
            }
            set
            {
                testContextInstance = value;
            }
        }

        #region Attributs de tests supplémentaires
        //
        // Vous pouvez utiliser les attributs supplémentaires suivants lorsque vous écrivez vos tests :
        //
        // Utilisez ClassInitialize pour exécuter du code avant d'exécuter le premier test de la classe
        // [ClassInitialize()]
        // public static void MyClassInitialize(TestContext testContext) { }
        //
        // Utilisez ClassCleanup pour exécuter du code une fois que tous les tests d'une classe ont été exécutés
        // [ClassCleanup()]
        // public static void MyClassCleanup() { }
        //
        // Utilisez TestInitialize pour exécuter du code avant d'exécuter chaque test 
        // [TestInitialize()]
        // public void MyTestInitialize() { }
        //
        // Utilisez TestCleanup pour exécuter du code après que chaque test a été exécuté
        // [TestCleanup()]
        // public void MyTestCleanup() { }
        //
        #endregion


        [TestMethod]

        public void TestSherlock()
        {
            Game game = new Game();
            game.StartNewGame(PlayerType.MrJack, Difficulty.Easy);
            GameBoard GB = game.GameBoard as GameBoard;
            Rnd = new Random();
            int nb = Rnd.Next(1, 3);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    
                    if (GB.Board[i, j].Detective == Detectives.Sherlock)
                    {
                        //on teste bien qu'on utilise Sherlock en le comparant avec les positions sur le gameboard
                        Assert.IsTrue(GB.Board[i, j].Detective == Detectives.Sherlock);
                        //On teste si GB.Board[i,j].Detective a changer apres avoir executer game.moveDetective
                        MrJack.Core.Domain.Game.Detectives testMD1 = GB.Board[i, j].Detective;
                        Game.MoveDetective(2, i, j, nb);
                        MrJack.Core.Domain.Game.Detectives testMD2 = GB.Board[i, j].Detective;
                        Assert.IsTrue(testMD1 != testMD2);
                        

                    }
                }
            }
        }
        public void TestWatson(int actionIndex)
        {
            //TODO: tester la fonction
            int nb = Rnd.Next(1, 3);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (GB.Board[i, j].Detective == Detectives.Watson)
                    {
                        //on teste bien qu'on utilise watson en le comparant avec les positions sur le gameboard
                        Assert.IsTrue(GB.Board[i, j].Detective == Detectives.Watson);
                        //On teste si GB.Board[i,j].Detective a changer apres avoir executer game.moveDetective
                        MrJack.Core.Domain.Game.Detectives testMD1 = GB.Board[i, j].Detective;
                        Game.MoveDetective(actionIndex, i, j, nb);
                        MrJack.Core.Domain.Game.Detectives testMD2 = GB.Board[i, j].Detective;
                        Assert.IsTrue(testMD1 != testMD2);
                        
                    }
                }
            }
        }
        public void TestToby(int actionIndex)
        {
            //TODO: Test fonction
            int nb = Rnd.Next(1, 3);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (GB.Board[i, j].Detective == Detectives.Toby)
                    {
                        //on teste bien qu'on utilise Toby en le comparant avec les positions sur le gameboard
                        Assert.IsTrue(GB.Board[i, j].Detective == Detectives.Toby);
                        //On teste si GB.Board[i,j].Detective a changer apres avoir executer game.moveDetective
                        MrJack.Core.Domain.Game.Detectives testMD1 = GB.Board[i, j].Detective;
                        Game.MoveDetective(actionIndex, i, j, nb);
                        MrJack.Core.Domain.Game.Detectives testMD2 = GB.Board[i, j].Detective;
                        Assert.IsTrue(testMD1 != testMD2);
                        
                    }
                }
            }
        }

        public void TestJoker(int actionIndex)
        {
            //TODO: Test fonction
            Detectives joker;
            int nbjeton = Rnd.Next(1, 3);
            if (nbjeton == 1)
            {
                Assert.IsTrue(nbjeton == 1);
                joker = Detectives.Sherlock;
            }
            else if (nbjeton == 2)
            {
                Assert.IsTrue(nbjeton == 2);
                joker = Detectives.Watson;
            }
            else
            {
                Assert.IsTrue(nbjeton != 1 && nbjeton != 2);
                joker = Detectives.Toby;
            }

            int nb = Rnd.Next(0, 2);
            for (int i = 0; i <= 5; i++)
            {
                for (int j = 0; j <= 5; j++)
                {
                    if (GB.Board[i, j].Detective == joker)
                    {
                        // on teste bien qu'on utilise Joker en le comparant avec les positions sur le gameboard
                        Assert.IsTrue(GB.Board[i, j].Detective == joker);
                        //On teste si GB.Board[i,j].Detective a changer apres avoir executer game.moveDetective
                        MrJack.Core.Domain.Game.Detectives testMD1 = GB.Board[i, j].Detective;
                        Game.MoveDetective(actionIndex, i, j, nb);
                        MrJack.Core.Domain.Game.Detectives testMD2 = GB.Board[i, j].Detective;
                        Assert.IsTrue(testMD1 != testMD2);
                    }
                }
            }
        }
        public void TestMove(int actionIndex)
        {
            int x1 = Rnd.Next(1, 4);
            int y1 = Rnd.Next(1, 4);
            int x2 = Rnd.Next(1, 4);
            int y2 = Rnd.Next(1, 4);
            //verifier que x1 a bien pris la valeur de x2 apres le Game.MoveCard, meme chose pour y1 et y2
            
            Game.MoveCard(actionIndex, x1, y1, x2, y2);
            
        }
        public void TestTurn(int actionIndex)
        {
            int x = Rnd.Next(1, 4);
            int y = Rnd.Next(1, 4);
            int nb = Rnd.Next(1, 4);
            Game.TurnCard(actionIndex, x, y, nb);
        }



        public void TestChooseAction()
        {
            //
            // TODO: ajoutez ici la logique du test
            //
            //for (int actionIndex = 0; actionIndex < Game.AvailableActions.Count; actionIndex++)
            //{
            //    if (Game.AvailableActions[actionIndex].Selectable)
            //    {
            //        if (Game.AvailableActions[actionIndex].ActionType == ActionType.Draw)
            //        {
            //            Draw(actionIndex);
            //        }
            //        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Joker)
            //        {
            //            Joker(actionIndex);
            //        }
            //        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Move)
            //        {
            //            Move(actionIndex);
            //        }
            //        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Sherlock)
            //        {
            //            Sherlock(actionIndex);
            //        }
            //        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Toby)
            //        {
            //            Toby(actionIndex);
            //        }
            //        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Turn)
            //        {
            //            Turn(actionIndex);
            //        }
            //        else if (Game.AvailableActions[actionIndex].ActionType == ActionType.Watson)
            //        {
            //            Watson(actionIndex);
            //        }
            //    }
            //}
        }
    }
}
