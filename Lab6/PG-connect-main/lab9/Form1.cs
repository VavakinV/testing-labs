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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PG.OpenConnection("127.0.0.1", "5432", "postgres", "123", "StudentsDB");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            CRUD g = new CRUD();
            g.table = "specialities";
            g.pk_name = "specialtyid";
            g.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            CRUD g = new CRUD();
            g.table = "v1";
            g.view = true;
            g.n = (int)PG.Select_size("v1");
            g.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            CRUD g = new CRUD();
            g.table = "sets";
            g.pk_name = "setid";
            g.pk_name2 = "setyear";
            //g.allow_upd = false;
            g.Show();
        }
    }
}
