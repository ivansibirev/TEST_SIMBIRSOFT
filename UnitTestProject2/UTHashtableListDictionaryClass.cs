using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTHashtableListDictionaryClass
    {
        [TestMethod]
        public void UT_HLDC_00()
        {
            T.HashtableListDictionaryClass DC = new T.HashtableListDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_HLDC_01()
        {
            T.HashtableListDictionaryClass DC = new T.HashtableListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }
        [TestMethod]
        public void UT_HLDC_03()
        {
            T.HashtableListDictionaryClass DC = new T.HashtableListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_HLDC_04()
        {
            T.HashtableListDictionaryClass DC = new T.HashtableListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
