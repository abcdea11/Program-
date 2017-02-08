using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApplication9
{
    public partial class klient : Form
    {
        public klient()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                klient_prywatny form = new klient_prywatny();
                form.Show();
            }

            if (checkBox2.Checked)
            {
                klient_firma form = new klient_firma();
                form.Show();

            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
