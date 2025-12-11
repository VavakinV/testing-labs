using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace postrg3
{
    public class PG
    {
        private static NpgsqlConnection con = null;

        public static List<List<string>> Select_all(string table_view)
        {
            List<List<string>> list = new List<List<string>>();
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = "Select * from public.\"" + table_view + "\"";
                    NpgsqlDataReader dt = com.ExecuteReader(CommandBehavior.Default);
                    List<string> list_names = new List<string>();
                    for (int i = 0; i < dt.FieldCount; i++)
                    {
                        list_names.Add(dt.GetName(i));
                    }
                    list.Add(list_names);
                    while (dt.Read())
                    {
                        try
                        {
                            List<string> inside_list = new List<string>();
                            for (int i = 0; i < dt.FieldCount; i++)
                            {
                                inside_list.Add(dt.GetValue(i).ToString());
                            }
                            list.Add(inside_list);
                        }
                        catch (Exception ex) { MessageBox.Show(ex.Message); }
                    }
                    dt.Close();
                }
                else throw new Exception("Not Opened Connection!");
            }
            else throw new Exception("Not Connected!");
            return list;
        }
        public static void OpenConnection(string host, string port, string user, string pass, string db)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open) con.Close();
                con.Dispose();
            }
            con = new NpgsqlConnection(@"Server=" + host + ";Port=" + port + ";User Id=" + user + ";Password=" + pass + ";Database=" + db + ";");
            con.Open();
            if (con.State == ConnectionState.Open) { }// MessageBox.Show("Connected!");
            else MessageBox.Show("NOT Connected!");
        }
    }

    static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
