using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using Npgsql;

namespace postgr2
{
    public class PG
    {
        private static NpgsqlConnection con = null;

        public static void Populate_grid(string table_view, DataGridView g, int n, int k)
        {
            try
            {
                List<List<string>> list_list = k == -1 ? Select_all(table_view) : Select_n_k(table_view, n, k);
                g.Rows.Clear();
                g.Columns.Clear();
                foreach (string ss in list_list[0])
                {
                    g.Columns.Add(ss, ss);
                }
                bool skip1 = false;
                foreach (List<string> list in list_list)
                {
                    if (skip1)
                    {
                        string[] v = new string[list.Count];
                        int kk = 0;
                        foreach (string ss in list)
                        {
                            v[kk] = ss;
                            kk++;
                        }
                        g.Rows.Add(v);
                    }
                    skip1 = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error!\n" + ex.Message); }
        }

        public static void Populate_FK_grid(string table_view, DataGridView g, string id_name, string id)
        {
            try
            {
                List<List<string>> list_list = Select_1FK(table_view, id_name, id);
                g.Rows.Clear();
                g.Columns.Clear();
                foreach (string ss in list_list[0])
                {
                    g.Columns.Add(ss, ss);
                }
                bool skip1 = false;
                foreach (List<string> list in list_list)
                {
                    if (skip1)
                    {
                        string[] v = new string[list.Count];
                        int kk = 0;
                        foreach (string ss in list)
                        {
                            v[kk] = ss;
                            kk++;
                        }
                        g.Rows.Add(v);
                    }
                    skip1 = true;
                }
            }
            catch (Exception ex) { MessageBox.Show("Error!\n" + ex.Message); }
        }

        public static List<List<string>> Select_n_k(string table_view,int n,int k)
        {
            List<List<string>> list = new List<List<string>>();
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = "Select * from public.\"" + table_view
                        + "\" limit " + n.ToString() + " offset " + (n * k).ToString();
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

        public static List<List<string>> Select_1FK(string table_view, string id_name, string id)
        {
            List<List<string>> list = new List<List<string>>();
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = "Select * from public.\"" + table_view + "\"" +
                        " where \"" + id_name + "\" = " + id;
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

        public static long Select_size(string table_view)
        {
            long ret = 0;
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = "Select COUNT(*) from public.\"" + table_view + "\"";
                    ret = (long)com.ExecuteScalar();
                }
                else throw new Exception("Not Opened Connection!");
            }
            else throw new Exception("Not Connected!");
            return ret;
        }

        public static void Delete(string table_view, string id_name, string id)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = "delete from public.\"" + table_view +
                        "\" where \"" + id_name + "\" = " + id;
                    com.ExecuteNonQuery();
                }
                else throw new Exception("Not Opened Connection!");
            }
            else throw new Exception("Not Connected!");
        }

        public static void Delete2(string table_view, string id_name, string id, string id_name2, string id2)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = "delete from public.\"" + table_view +
                        "\" where \"" + id_name + "\" = " + id
                        + " and \"" + id_name2 + "\" = " + id2;
                    com.ExecuteNonQuery();
                }
                else throw new Exception("Not Opened Connection!");
            }
            else throw new Exception("Not Connected!");
        }

        public static void SendCU(string tcom)
        {
            if (con != null)
            {
                if (con.State == ConnectionState.Open)
                {
                    NpgsqlCommand com = con.CreateCommand();
                    com.CommandText = tcom;
                    com.ExecuteNonQuery();
                }
                else throw new Exception("Not Opened Connection!");
            }
            else throw new Exception("Not Connected!");
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
