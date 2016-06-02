using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTArrayListDictionaryClass
    {
        [TestMethod]
        public void UT_ALDC_00()
        {
            T.ArrayListDictionaryClass DC = new T.ArrayListDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_ALDC_01()
        {
            T.ArrayListDictionaryClass DC = new T.ArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }        
        [TestMethod]
        public void UT_ALDC_03()
        {
            T.ArrayListDictionaryClass DC = new T.ArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_ALDC_04()
        {
            T.ArrayListDictionaryClass DC = new T.ArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}