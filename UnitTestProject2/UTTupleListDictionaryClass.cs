using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTTupleListDictionaryClass
    {
        [TestMethod]
        public void UT_TLDC_00()
        {
            T.TupleListDictionaryClass DC = new T.TupleListDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.Count == 0);
        }
        [TestMethod]
        public void UT_TLDC_01()
        {
            T.TupleListDictionaryClass DC = new T.TupleListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Count == 6);
        }
        [TestMethod]
        public void UT_TLDC_03()
        {
            T.TupleListDictionaryClass DC = new T.TupleListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_TLDC_04()
        {
            T.TupleListDictionaryClass DC = new T.TupleListDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
