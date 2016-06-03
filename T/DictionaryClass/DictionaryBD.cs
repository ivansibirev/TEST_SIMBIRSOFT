using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace T
{
        public class DictionaryBDClass
         {
            // Используемые дополнительные материалы:
            // -"РАБОТА С БАЗАМИ ДАННЫХ НА ЯЗЫКЕ C#" О. Н. Евсеева, А. Б. Шамшев.
            // -"Библия C#, 2-е издание" М. Фленов

            //Строка подключения к BD Microsoft SQL Server 2014
            //string ConnectionString_ = @"Provider=SQLOLEDB.1;Integrated Security=SSPI;Persist Security Info=False;Initial Catalog=Dictionary;Data Source=MY-ПК";
            //Строка подключения к локальной файловой базе данных "Word.accdb"
            string ConnectionString_ = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=Word.accdb;Persist Security Info=False";
            public int Count_ = 0;
        /// <summary>Конструктор + загрузка из файла</summary>
        public DictionaryBDClass(string pathDictionary)
        {
            System.IO.StreamReader sr = new System.IO.StreamReader(pathDictionary);
            string s = "";
            System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection();
            connection.ConnectionString = ConnectionString_;
            try {
                this.Count_ = 0;
                connection.Open();
                System.Data.OleDb.OleDbCommand command_DEL = connection.CreateCommand();
                command_DEL.CommandText = "DELETE FROM Word;";
                command_DEL.ExecuteScalar();
                while ((s = sr.ReadLine()) != null)
                {
                    System.Data.OleDb.OleDbCommand command_INS = connection.CreateCommand();
                    command_INS.CommandText = "INSERT INTO Word (Слово,id) Values ('" + s + "','" + Convert.ToString( this.Count_) + "');";
                    command_INS.ExecuteScalar();
                    //connection.CreateCommand().CommandText = "INSERT INTO Word ValuesS ('"+s+"');";
                    this.Count_++;
                }
            }catch { System.Windows.Forms.MessageBox.Show("Увы, BD недоступна"); }
            sr.Close();
            if (connection.State == System.Data.ConnectionState.Open)connection.Close();            
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

                System.Data.OleDb.OleDbConnection connection = new System.Data.OleDb.OleDbConnection();
                connection.ConnectionString = ConnectionString_;
                try
                {
                    connection.Open();
                    ;
                    System.Data.OleDb.OleDbCommand command = connection.CreateCommand();
                    command.CommandText = "SELECT Слово FROM Word WHERE Слово='" + WorkWord + "';";//                    
                    //SELECT Слово FROM Word WHERE Слово= 'содержит';
                    System.Data.OleDb.OleDbDataReader reader = command.ExecuteReader();
                    int counterr = 0;
                    do{
                        while(reader.Read()){
                            counterr++;
                            //C.W.n();C.W.Red(reader["Слово"].ToString());C.W.n();
                        }
                    }while (reader.NextResult());
                    rez = (counterr >0);
                    
                }
                catch { System.Windows.Forms.MessageBox.Show("Увы, BD недоступна"); }
                if (connection.State == System.Data.ConnectionState.Open) connection.Close();
                
                //rez = this.LS.Contains(WorkWord);
            }
            return rez;
        }
    }
}