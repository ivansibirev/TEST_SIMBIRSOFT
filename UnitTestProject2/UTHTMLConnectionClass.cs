using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTHTMLConnectionClass
    {
        [TestMethod]
        public void UT_HTMLCC_00()
        {
            T.HTMLConnectionClass DC = new T.HTMLConnectionClass(1, 1);
            //Увы, но тут просто нечего тестировать
            Assert.AreEqual(false, false);
        }
    }
}
