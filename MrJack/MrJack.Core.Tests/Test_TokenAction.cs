using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core;
using MrJack.Core.Domain.Game;

namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Test_TokenAction
    {
        [TestMethod]
        public void Test_Lancer()
        {
            TokenAction Ta = new TokenAction();

            Assert.IsNull(Ta.Token1);
            Assert.IsNull(Ta.Token2);
            Assert.IsNull(Ta.Token3);
            Assert.IsNull(Ta.Token4);
            
            Ta.Lancer();
            
            Assert.IsTrue((Ta.Token1.ActionType == ActionType.Joker) || (Ta.Token1.ActionType == ActionType.Turn));
            Assert.IsTrue((Ta.Token2.ActionType == ActionType.Move) || (Ta.Token2.ActionType == ActionType.Turn));
            Assert.IsTrue((Ta.Token3.ActionType == ActionType.Draw) || (Ta.Token3.ActionType == ActionType.Sherlock));
            Assert.IsTrue((Ta.Token4.ActionType == ActionType.Toby) || (Ta.Token4.ActionType == ActionType.Watson));    
        }

        [TestMethod]
        public void Test_Tourner_Face1()
        {
            TokenAction Ta = new TokenAction();

            Ta.Token1 = new Token(ActionType.Joker);
            Ta.Token2 = new Token(ActionType.Move);
            Ta.Token3 = new Token(ActionType.Draw);
            Ta.Token4 = new Token(ActionType.Toby);

            Ta.Tourner();

            Assert.IsTrue(Ta.Token1.ActionType == ActionType.Turn, "ActionType T1: " +Ta.Token1.ActionType);
            Assert.IsTrue(Ta.Token2.ActionType == ActionType.Turn, "ActionType T2: " + Ta.Token2.ActionType);
            Assert.IsTrue(Ta.Token3.ActionType == ActionType.Sherlock, "ActionType T3: " + Ta.Token3.ActionType);
            Assert.IsTrue(Ta.Token4.ActionType == ActionType.Watson, "ActionType T4: " + Ta.Token4.ActionType);
        }
        [TestMethod]
        public void Test_Tourner_Face2()
        {
            TokenAction Ta = new TokenAction();

            Ta.Token1 = new Token(ActionType.Turn);
            Ta.Token2 = new Token(ActionType.Turn);
            Ta.Token3 = new Token(ActionType.Sherlock);
            Ta.Token4 = new Token(ActionType.Watson);

            Ta.Tourner();

            Assert.IsTrue(Ta.Token1.ActionType == ActionType.Joker);
            Assert.IsTrue(Ta.Token2.ActionType == ActionType.Move);
            Assert.IsTrue(Ta.Token3.ActionType == ActionType.Draw);
            Assert.IsTrue(Ta.Token4.ActionType == ActionType.Toby);
        }
    }
}
