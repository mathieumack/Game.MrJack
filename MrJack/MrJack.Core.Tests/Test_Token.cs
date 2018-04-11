using System;
using System.Diagnostics.CodeAnalysis;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MrJack.Core;
using MrJack.Core.Domain.Game;

namespace MrJack.Core.Tests
{
    [TestClass]
    [ExcludeFromCodeCoverage]
    public class Test_Token
    {
        [TestMethod]
        public void Test_CreateToken()
        {
            Token Token1 = new Token(ActionType.Draw);
            Token Token2 = new Token(ActionType.Joker);
            Token Token3 = new Token(ActionType.Move);
            Token Token4 = new Token(ActionType.Sherlock);
            Token Token5 = new Token(ActionType.Toby);
            Token Token6 = new Token(ActionType.Turn);
            Token Token7 = new Token(ActionType.Watson);

            Assert.IsTrue(Token1.ActionType == ActionType.Draw);
            Assert.IsTrue(Token1.Selectable);
            Assert.IsTrue(Token2.ActionType == ActionType.Joker);
            Assert.IsTrue(Token2.Selectable);
            Assert.IsTrue(Token3.ActionType == ActionType.Move);
            Assert.IsTrue(Token3.Selectable);
            Assert.IsTrue(Token4.ActionType == ActionType.Sherlock);
            Assert.IsTrue(Token4.Selectable);
            Assert.IsTrue(Token5.ActionType == ActionType.Toby);
            Assert.IsTrue(Token5.Selectable);
            Assert.IsTrue(Token6.ActionType == ActionType.Turn);
            Assert.IsTrue(Token6.Selectable);
            Assert.IsTrue(Token7.ActionType == ActionType.Watson);
            Assert.IsTrue(Token7.Selectable);
        }

        [TestMethod]
        public void Test_Token_ChangeSelectable()
        {
            Token Token1 = new Token(ActionType.Draw);
            Token1.Selectable = false;

            Assert.IsFalse(Token1.Selectable);
        }
    }
}
