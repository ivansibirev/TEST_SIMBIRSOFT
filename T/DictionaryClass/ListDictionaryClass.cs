using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
    public class ListDictionaryClass
    {
        public List<string> LS = new List<string>();
        /// <summary>Конструктор + загрузка из файла</summary>
        public ListDictionaryClass(string pathDictionary)
        {
            try{
                System.IO.StreamReader sr = new System.IO.StreamReader(pathDictionary);
                string s = "";
                while ((s = sr.ReadLine()) != null)
                    this.LS.Add(s);
                sr.Close();
            }catch{
                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.Open(pathDictionary, System.IO.FileMode.Create));
                sw.Close();
                System.IO.StreamReader sr = new System.IO.StreamReader(pathDictionary);
                string s = "";
                while ((s = sr.ReadLine()) != null)
                    this.LS.Add(s);
                sr.Close();
            }
        }
        /// <summary>Получить содержимое словаря в виде строки для вывода на экран.</summary>
        public string ThisToString()
        {
            string rez = "Dictionary:";
            foreach (string s in this.LS)
                rez += "\n  " + s;
            rez += "\n" + "end;";
            return rez;
        }
        /// <summary>Проверка, есть ли слово в словаре?</summary>
        /// <param name="TheWord">Проверяемое слово</param>
        /// <returns>bool rez</returns>
        public bool Contains_(string TheWord)
        {
            bool rez = false;
            if (TheWord.Length > 0)
            {
                string WorkWord = "";
                {   //На случай если после слова без пробела идёт один из символ "., "
                    WorkWord += TheWord.Substring(0, TheWord.Length - 1);
                    if ((TheWord[TheWord.Length - 1] != '.') &&
                        (TheWord[TheWord.Length - 1] != ',') &&
                        (TheWord[TheWord.Length - 1] != ' ') &&
                        (TheWord[TheWord.Length - 1] != '?') &&
                        (TheWord[TheWord.Length - 1] != '!')
                        )
                        WorkWord += TheWord[TheWord.Length - 1];
                }
                rez = this.LS.Contains(WorkWord);
            }
            return rez;
        }
    }
}