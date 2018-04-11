using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace MrJack.Core.Tests
{
    [TestClass]
    public class TokenActionTest
    {
        [TestMethod]
        public void TestMethod1()
        {
            Assert.IsTrue(TokenAction.lancer());
        }
    }
}
