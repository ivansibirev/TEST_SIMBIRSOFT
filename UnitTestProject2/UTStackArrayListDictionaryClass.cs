using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTStackArrayListDictionaryClass
    {
        [TestMethod]
        public void UT_SALDC_00()
        {
            T.StackArrayListDictionaryClass DC = new T.StackArrayListDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_SALDC_01()
        {
            T.StackArrayListDictionaryClass DC = new T.StackArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }
        [TestMethod]
        public void UT_SALDC_03()
        {
            T.StackArrayListDictionaryClass DC = new T.StackArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_SALDC_04()
        {
            T.StackArrayListDictionaryClass DC = new T.StackArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
