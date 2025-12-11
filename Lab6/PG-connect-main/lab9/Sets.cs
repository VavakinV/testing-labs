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
    public partial class Sets : Form
    {
        public CRUD parent;
        public bool empty_start = true;

        public string Aid = "";
        public string Aname = "";
        public string Ayear = "";
        public string Aspec = "";

        public Sets()
        {
            InitializeComponent();
        }

        private void Sets_Load(object sender, EventArgs e)
        {
            textBox1.Text = Aname;
            textBox2.Text = Ayear;
            if (Aspec != "")
            {
                PG.Populate_FK_grid("specialities", dataGridView1, "specialtyid", Aspec);
                //button3.Hide();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string year = textBox2.Text;

            if ((name != "") && (year != "") && (Aspec != ""))
            {
                if (empty_start)
                    parent.tcom = "insert into sets values (DEFAULT, '" +
                        name + "','" + year + "','" + Aspec + "');";
                else
                    parent.tcom = "UPDATE sets " +
                        "SET setname = '" + name
                        + "', setyear = '" + year
                        + "', specialtyid = '" + Aspec
                        + "'WHERE setid = " + Aid + ";";

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUD g = new CRUD();
            g.table = "specialities";
            g.view = true;
            g.sel_id_name = "specialtyid";
            g.ShowDialog();
            if (g.DialogResult == DialogResult.OK)
            {
                Aspec = g.sel_id;
                PG.Populate_FK_grid("specialities", dataGridView1, "specialtyid", Aspec);
            }
        }
    }
}
