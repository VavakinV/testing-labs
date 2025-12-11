using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace postgr2
{
    public partial class CRUD : Form
    {
        public bool view = false;
        public bool allow_upd = true;
        public string table = "";
        public string pk_name = "";
        public string pk_name2 = "";
        public int n = 5;

        public string tcom = "";

        public string sel_id_name = "";
        public string sel_id = "";

        private int sz = 0;
        private int pages = 0;
        public CRUD()
        {
            InitializeComponent();
        }

        private void resize()
        {
            if (table != "")
            {
                sz = (int)PG.Select_size(table);
                pages = sz / n + (sz % n == 0 ? 0 : 1);
            }
        }

        private void reload_view()
        {
            int pg = Convert.ToInt32(textBox1.Text);
            if (table != "") PG.Populate_grid(table, dataGridView1, n, pg - 1);
        }

        private void CRUD_Load(object sender, EventArgs e)
        {
            resize();
            reload_view();
            if (view)
            {
                button1.Hide();
                button2.Hide();
                button3.Hide();
            }
            if (!allow_upd) button2.Hide();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int pg = Convert.ToInt32(textBox1.Text);
            if (pg > 1) textBox1.Text = (pg - 1).ToString();
            reload_view();
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            int pg = Convert.ToInt32(textBox1.Text);
            if (pg < pages) textBox1.Text = (pg + 1).ToString();
            reload_view();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            int pg;
            try
            {
                pg = Convert.ToInt32(textBox1.Text);
                if ((pg < 1) || (pg > pages)) throw new Exception("pg");
            }
            catch (Exception)
            {
                pg = 1;
                textBox1.Text = "1";
            }
            textBox1.Text = pg.ToString();
            reload_view();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if ((table != "") && (pk_name != "") && (pk_name2 != ""))
            {
                foreach (DataGridViewRow x in dataGridView1.SelectedRows)
                    PG.Delete2(table, pk_name, (string)x.Cells[pk_name].Value,
                        pk_name2, (string)x.Cells[pk_name2].Value);
            }
            else if((table != "") && (pk_name != ""))
            {
                foreach (DataGridViewRow x in dataGridView1.SelectedRows)
                    PG.Delete(table, pk_name, (string)x.Cells[pk_name].Value);
            }
            resize();
            reload_view();
            if (dataGridView1.Rows.Count == 0)
            {
                int pg = Convert.ToInt32(textBox1.Text);
                if (pg > 1) textBox1.Text = (pg - 1).ToString();
                reload_view();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (table == "specialities")
            {
                Specs s = new Specs();
                s.parent = this;
                s.empty_start = true;
                DialogResult d = s.ShowDialog();
                if (d == DialogResult.OK)
                {
                    PG.SendCU(tcom);
                    resize();
                    reload_view();
                }
            }
            if (table == "sets")
            {
                Sets s = new Sets();
                s.parent = this;
                s.empty_start = true;
                DialogResult d = s.ShowDialog();
                if (d == DialogResult.OK)
                {
                    PG.SendCU(tcom);
                    resize();
                    reload_view();
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count != 0)
            {
                if (table == "specialities")
                {
                    Specs s = new Specs();
                    s.parent = this;
                    s.empty_start = false;

                    s.Aid = (string)dataGridView1.SelectedRows[0].Cells["specialtyid"].Value;
                    s.Aname = (string)dataGridView1.SelectedRows[0].Cells["specialtyname"].Value;
                    s.Acode = (string)dataGridView1.SelectedRows[0].Cells["specialtycode"].Value;
                    s.Adesc = (string)dataGridView1.SelectedRows[0].Cells["descript"].Value;

                    DialogResult d = s.ShowDialog();
                    if (d == DialogResult.OK)
                    {
                        PG.SendCU(tcom);
                        resize();
                        reload_view();
                    }
                }
                if (table == "sets")
                {
                    Sets s = new Sets();
                    s.parent = this;
                    s.empty_start = false;

                    s.Aid = (string)dataGridView1.SelectedRows[0].Cells["setid"].Value;
                    s.Aname = (string)dataGridView1.SelectedRows[0].Cells["setname"].Value;
                    s.Ayear = (string)dataGridView1.SelectedRows[0].Cells["setyear"].Value;
                    s.Aspec = (string)dataGridView1.SelectedRows[0].Cells["specialtyid"].Value;

                    DialogResult d = s.ShowDialog();
                    if (d == DialogResult.OK)
                    {
                        PG.SendCU(tcom);
                        resize();
                        reload_view();
                    }
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if ((dataGridView1.SelectedRows.Count != 0)&& (sel_id_name != ""))
                sel_id = (string)dataGridView1.SelectedRows[0].Cells[sel_id_name].Value;
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
