using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//using System.Windows.Forms;
using MultiDictionary = T.DictionaryClassEntityFramework;
//using MultiDictionary = T.DictionaryBDClass;
//using MultiDictionary = T.ArrayDictionaryClass;
//using MultiDictionary = T.ArrayListDictionaryClass;
//using MultiDictionary = T.DictionaryClass;
//using MultiDictionary = T.DictionaryDictionaryClass;
//using MultiDictionary = T.HashtableListDictionaryClass;
//using MultiDictionary = T.ListDictionaryClass;
//using MultiDictionary = T.QueueArrayListDictionaryClass;
//using MultiDictionary = T.StackArrayListDictionaryClass;
//using MultiDictionary = T.TupleListDictionaryClass;
namespace T
{
    class Program
    {
        static void Main(string[] args){

            
                //Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Dictionary;Data Source=ЙЦУКЕНГУРУ-ПК
            DoIt("TheTextFile.txt", "Dictionary.txt",10);            
            Console.Read();
        }
        /// <summary>Метод, готовый к использованию.</summary>
        /// <param name="TextFilePath">Путь к тексту</param>
        /// <param name="DictionaryFilePath">Путь к словарю.</param>
        /// <param name="MaxLineCount">Максимум предложений в HTMl файле</param>
        static void DoIt(string TextFilePath, string DictionaryFilePath, int MaxLineCount)
        {
            MultiDictionary myDictionary = new MultiDictionary(DictionaryFilePath);
            try {
                System.IO.StreamReader sr = System.IO.File.OpenText(TextFilePath);
                sr.Close();
            }
            catch {
                System.IO.StreamWriter sw = new System.IO.StreamWriter(System.IO.File.Open(TextFilePath, System.IO.FileMode.Create));
                sw.Close();
            }
            using (System.IO.StreamReader sr = System.IO.File.OpenText(TextFilePath))
            {
                string s = "";//Для чтения из TextFilePath
                string StringOverview = "";//Строка "обзора конца предложения".
                string a = "";//Вспомогательная переменная
                HTMLConnectionClass HTMLConnection = new HTMLConnectionClass(MaxLineCount, 1);
                XMLConnectionClass XMLConnection = new XMLConnectionClass(MaxLineCount, 1);
                
                Func<string, object> Writer = (string w) =>
                {   //Лямбда-выражение или функция централизованного вывода (записи) текста на экран, в HTML файл...
                    if (HTMLConnection.counter > HTMLConnection.maxcount)
                    {   //Смена HTML файла
                        HTMLConnection.fin(); XMLConnection.fin();
                        HTMLConnectionClass newHTMLConnection = new HTMLConnectionClass(HTMLConnection.maxcount, HTMLConnection.id + 1);
                        XMLConnectionClass newXMLConnection = new XMLConnectionClass(XMLConnection.maxcount, XMLConnection.id + 1);
                        HTMLConnection = newHTMLConnection;
                        XMLConnection = newXMLConnection;
                    }
                    foreach (string str in a.Split(' '))
                    {   //Пишем текст
                        if (myDictionary.Contains_(str))
                        {   //Проверка, есть ли в словаре слово.
                            C.W.Cyan(str + " ");//Пишем на экран в цвере.
                            HTMLConnection.WriteLine("<i><b>" + str + "</b></i>");//Пишем в HTML жирным курсивом.
                            XMLConnection.WriteLine(str,true);
                        }
                        else
                        {
                            C.W.Gray(str + " ");
                            HTMLConnection.WriteLine(str);
                            XMLConnection.WriteLine(str, false);
                        }
                    }
                    C.W.n();
                    HTMLConnection.WriteLine("<br>");
                    HTMLConnection.counter++;
                    XMLConnection.counter++;
                    return new object();
                };
                while ((s = sr.ReadLine()) != null)
                {   //Читаем из исходного файла текст
                    StringOverview = StringOverview + " " + s;
                    if (StringOverview.Contains(". "))
                    {//Отслеживаем наличие конца предложения и переходим к действиям
                        a = StringOverview.Substring(0, StringOverview.IndexOf(". ") + 1);
                        Writer(a);
                        StringOverview = StringOverview.Substring(StringOverview.IndexOf(". ") + 1);
                    }
                }
                a = StringOverview;
                Writer(a);
                HTMLConnection.fin();
                sr.Close();
            }
        }
    }
    

}
