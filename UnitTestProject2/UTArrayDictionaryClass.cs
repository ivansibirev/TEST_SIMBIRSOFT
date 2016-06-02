using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace UnitTestProject2
{
    [TestClass]
    public class UTArrayDictionaryClass
    {
        [TestMethod]
        public void UT_ADC_00()
        {
            T.ArrayDictionaryClass DC = new T.ArrayDictionaryClass("Dictionary_UT.txt");
            Assert.AreEqual(true, DC.Count == 0);
        }
        [TestMethod]
        public void UT_ADC_01()
        {
            T.ArrayDictionaryClass DC = new T.ArrayDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Count == 6);
        }
        [TestMethod]
        public void UT_ADC_02()
        {
            T.ArrayDictionaryClass DC = new T.ArrayDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.LS[4] == "виде");
        }
        [TestMethod]
        public void UT_ADC_03()
        {
            T.ArrayDictionaryClass DC = new T.ArrayDictionaryClass("Dictionary.txt");
            Assert.AreEqual(true, DC.Contains_("виде"));
        }
        [TestMethod]
        public void UT_ADC_04()
        {
            T.ArrayDictionaryClass DC = new T.ArrayDictionaryClass("Dictionary.txt");
            Assert.AreEqual(false, DC.Contains_("видел=)"));
        }
    }
}
