using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApplication9
{
    public partial class Logincs : Form
    {    // metody // Łączenie z bazą

        SqlConnection con = new SqlConnection();





        //






        public Logincs()
        {
            InitializeComponent();
        }

        private void Logincs_Load(object sender, EventArgs e)
        {


            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = char.MinValue;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox2.PasswordChar = '#';
        }

        private void button1_Click(object sender, EventArgs e)
        {
            textBox1.Text = " ";
            textBox2.Clear();
            textBox1.Focus();                   // kursor automatycznie przechodzi do 1 text box
        }

        private void button2_Click(object sender, EventArgs e)
        {

            this.Hide();                    // ukrywanie obecnej formy
            Form1 form1 = new Form1();
            form1.Show();
        }
    }
}
