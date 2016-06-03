using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
    public class XMLConnectionClass
    {//http://habrahabr.ru/post/24673/
        public string path = "";
        public int maxcount = 10;
        public int counter = 0;
        public int id = 0;        
        public System.Xml.Linq.XDocument doc = new System.Xml.Linq.XDocument();
        System.Xml.Linq.XElement WordER = new System.Xml.Linq.XElement("Text");
        public XMLConnectionClass(int _maxcount, int _id)
        {
            System.Xml.XmlDocument QWE = new System.Xml.XmlDocument();
            if (_id > 0) this.id = _id;
            this.path = "XML" + Convert.ToString(this.id) + ".XML";
            if (_maxcount > 10) this.maxcount = _maxcount;
            System.Xml.Linq.XElement WordERar = new System.Xml.Linq.XElement(this.path);
            doc.Add(WordERar);
        }
        /// <summary>Запись в HTML файл.</summary>
        public void WriteLine(string s, bool Dictionary)
        {
            System.Xml.Linq.XElement Word = new System.Xml.Linq.XElement("Word");
            Word.Add(new System.Xml.Linq.XAttribute("Word", s));
            Word.Add(new System.Xml.Linq.XAttribute("IsInnDictionary", Dictionary));
            WordER.Add(Word);
        }
        /// <summary>Завершение записи в файл.</summary>
        public void fin()
        {
            doc.Root.Add(WordER);
            doc.Save(this.path);
        }
    }
}