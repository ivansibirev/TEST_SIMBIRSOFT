using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTQueueArrayListDictionaryClass
    {
        [TestMethod]
        public void UT_QALDC_00()
        {
            T.QueueArrayListDictionaryClass DC = new T.QueueArrayListDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.LS.Count == 0);
        }
        [TestMethod]
        public void UT_QALDC_01()
        {
            T.QueueArrayListDictionaryClass DC = new T.QueueArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS.Count == 6);
        }
        [TestMethod]
        public void UT_QALDC_03()
        {
            T.QueueArrayListDictionaryClass DC = new T.QueueArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_QALDC_04()
        {
            T.QueueArrayListDictionaryClass DC = new T.QueueArrayListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
