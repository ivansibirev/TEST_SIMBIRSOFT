using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTListDictionaryClass
    {
        [TestMethod]
        public void UT_LDC_00()
        {
            T.ListDictionaryClass DC = new T.ListDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_LDC_01()
        {
            T.ListDictionaryClass DC = new T.ListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }
        [TestMethod]
        public void UT_LDC_03()
        {
            T.ListDictionaryClass DC = new T.ListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_LDC_04()
        {
            T.ListDictionaryClass DC = new T.ListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
