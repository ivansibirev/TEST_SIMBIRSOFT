using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
    /// <summary>Класс организует запись в HTML файл.</summary>
    public class HTMLConnectionClass
    {
        public string path = "";
        public int maxcount = 10;
        public int counter = 0;
        public int id = 0;        
        public HTMLConnectionClass(int _maxcount,int _id)
        {
            if (_id > 0) this.id = _id;
            this.path = "HTML"+Convert.ToString(this.id)+".htm";
            if (_maxcount > 10) this.maxcount = _maxcount;
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.Open(this.path, System.IO.FileMode.Create));
            sw.WriteLine("<!DOCTYPE html>");
            sw.WriteLine("<html>");
            sw.WriteLine(" <head>");
            sw.WriteLine("  <meta charset='utf-8'/>");
            sw.WriteLine("  <title> Титульник</title>");
            sw.WriteLine(" </head>");
            sw.WriteLine(" <body>");
            sw.Close();
        }
        /// <summary>Запись в HTML файл.</summary>
        public void WriteLine(string s)
        {
            System.IO.StreamWriter sw_HTML = new System.IO.StreamWriter(System.IO.File.Open(this.path, System.IO.FileMode.Append));
            sw_HTML.WriteLine(s);
            sw_HTML.Close();
        }
        /// <summary>Завершение записи в файл.</summary>
        public void fin()
        {
            System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.Open(this.path, System.IO.FileMode.Append));
            sw.WriteLine(" </body>");
            sw.WriteLine("</html>");
            sw.Close();
        }
    }
}
