using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTDictionaryClass
    {
        [TestMethod]
        public void UT_DC_00()
        {
            T.DictionaryClass DC = new T.DictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_DC_01()
        {
            T.DictionaryClass DC = new T.DictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }
        [TestMethod]
        public void UT_DC_02()
        {
            T.DictionaryClass DC = new T.DictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS[4] == "виде");
        }
        [TestMethod]
        public void UT_DC_03()
        {
            T.DictionaryClass DC = new T.DictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_DC_04()
        {
            T.DictionaryClass DC = new T.DictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
