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
    public partial class Specs : Form
    {
        public CRUD parent;
        public bool empty_start = true;

        public string Aid = "";
        public string Aname = "";
        public string Acode = "";
        public string Adesc = "";

        public Specs()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string name = textBox1.Text;
            string code = textBox2.Text;
            string desc = textBox3.Text;

            if ((name != "") && (code != "") && (desc != ""))
            {
                if (empty_start)
                    parent.tcom = "insert into specialities values (DEFAULT, '" +
                        name + "','" + code + "','" + desc + "');";
                else
                    parent.tcom = "UPDATE specialities " +
                        "SET specialtyname = '" + name
                        + "', specialtycode = '" + code
                        + "', descript = '" + desc
                        + "'WHERE specialtyid = " + Aid + ";";

                DialogResult = DialogResult.OK;
                Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void Specs_Load(object sender, EventArgs e)
        {
            textBox1.Text = Aname;
            textBox2.Text = Acode;
            textBox3.Text = Adesc;
        }
    }
}
