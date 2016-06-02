using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTDictionaryDictionaryClass
    {
        [TestMethod]
        public void UT_DDC_00()
        {
            T.DictionaryDictionaryClass DC = new T.DictionaryDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_DDC_01()
        {
            T.DictionaryDictionaryClass DC = new T.DictionaryDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }
        [TestMethod]
        public void UT_DDC_03()
        {
            T.DictionaryDictionaryClass DC = new T.DictionaryDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_DDC_04()
        {
            T.DictionaryDictionaryClass DC = new T.DictionaryDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}