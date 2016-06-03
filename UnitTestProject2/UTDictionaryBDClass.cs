using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTDictionaryBDClass
    {
        
        [TestMethod]
        public void UT_DBDC_00()
        {
            T.DictionaryBDClass DC = new T.DictionaryBDClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.Count_ == 0);
        }
        [TestMethod]
        public void UT_DBDC_01()
        {
            T.DictionaryBDClass DC = new T.DictionaryBDClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Count_ == 6);
        }
        [TestMethod]
        public void UT_DBDC_03()
        {
            T.DictionaryBDClass DC = new T.DictionaryBDClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_DBDC_04()
        {
            T.DictionaryBDClass DC = new T.DictionaryBDClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
         
    }
}
