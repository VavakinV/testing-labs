using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postgr
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                PG.OpenConnection(textBox1.Text, textBox2.Text, textBox3.Text, textBox4.Text, textBox5.Text);
            }
            catch(Exception ex) { MessageBox.Show("Error!\n" + ex.Message); }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //PG.OpenConnection("127.0.0.1", "5432", "postgres", "123", "StudentsDB");
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                List<List<string>> list_list = PG.Select_all(textBox6.Text);
                dataGridView1.Rows.Clear();
                dataGridView1.Columns.Clear();
                foreach (string ss in list_list[0])
                {
                    dataGridView1.Columns.Add(ss, ss);
                }
                bool skip1 = false;
                foreach (List<string> list in list_list)
                {
                    if (skip1)
                    {
                        string[] v = new string[list.Count];
                        int k = 0;
                        foreach (string ss in list)
                        {
                            v[k] = ss;
                            k++;
                        }
                        dataGridView1.Rows.Add(v);
                    }
                    skip1 = true;
                }

                //resize
                dataGridView1.AutoResizeColumns();
                dataGridView1.AutoResizeRows();
                dataGridView1.Width = dataGridView1.RowHeadersWidth
                    + dataGridView1.Columns.GetColumnsWidth(DataGridViewElementStates.Visible) + 24;
                dataGridView1.Height = Math.Min(dataGridView1.ColumnHeadersHeight
                    + dataGridView1.Rows.GetRowsHeight(DataGridViewElementStates.Visible) + 32, 400);
                dataGridView1.Refresh();
                if (dataGridView1.Left + dataGridView1.Width + 32 > Width)
                    Width += dataGridView1.Left + dataGridView1.Width + 32 - Width;
                if (dataGridView1.Top + dataGridView1.Height + 64 > Height)
                    Height += dataGridView1.Top + dataGridView1.Height + 64 - Height;
            }
            catch (Exception ex) { MessageBox.Show("Error!\n" + ex.Message); }
        }
    }
}
