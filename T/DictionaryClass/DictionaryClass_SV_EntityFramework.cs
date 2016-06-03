using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
    public class DictionaryClassEntityFramework
    {
        public class EFDictionary
        {
            public int Id { get; set; }
            public string Word { get; set; }
        }
        public class SyperDiContext : System.Data.Entity.DbContext
        {
            public System.Data.Entity.DbSet<EFDictionary> Di { get; set; }
        }
        public SyperDiContext db = new SyperDiContext();
        public int  Count_=0;
        public DictionaryClassEntityFramework(string pathDictionary)
        {
            try
            {
                System.IO.StreamReader sr = new System.IO.StreamReader(pathDictionary);
                string s = "";
                Count_ = 0;
                while ((s = sr.ReadLine()) != null)
                {
                    EFDictionary syperDi = new EFDictionary();
                    syperDi.Id = Count_;
                    syperDi.Word = s;
                    db.Di.Add(syperDi);
                    Count_++;
                    //   this.LS.Add(s);
                }
                sr.Close();
                db.SaveChanges();
            }
            catch
            {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.Open(pathDictionary, System.IO.FileMode.Create));
                sw.Close();
                System.IO.StreamReader sr = new System.IO.StreamReader(pathDictionary);
                string s = "";
                while ((s = sr.ReadLine()) != null)
                {
                    var syperDi = new EFDictionary { Word = s };
                    db.Di.Add(syperDi);
                    //   this.LS.Add(s);
                }
                sr.Close();
                db.SaveChanges();
            }
             
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
                var query = from b in db.Di
                            orderby b.Word
                            where b.Word == WorkWord
                            select b.Word;
                int COUNTERR = 0;
                foreach (var item in query)
                {
                    COUNTERR++;
                }
                rez = (COUNTERR > 0);
                //rez = this.LS.Contains(WorkWord);
            }
            return rez;
        }
    }
}
