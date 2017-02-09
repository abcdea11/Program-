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
    public partial class Auto : Form
    {
        public Auto()
        {
            InitializeComponent();
        }
        // metody
        public void Usun()
        {
            string tekst = "Czy na pewno chcesz usunąć wiersz?";
            string tytul = "Usuwanie";
            MessageBoxButtons przyciski = MessageBoxButtons.YesNo;
            MessageBoxIcon ikona = MessageBoxIcon.Warning;
            if (MessageBox.Show(tekst, tytul, przyciski, ikona) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                ZapisXml();
            }
        }

        public void ZapisXml()
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Samochody";
            dt1.Columns.Add("Marka");
            dt1.Columns.Add("Model");
            dt1.Columns.Add("Nr. Rejestracyjny");
            dt1.Columns.Add("Pojemność Silnika");
            dt1.Columns.Add("VIN");
            dt1.Columns.Add("Numer Silnika");
            dt1.Columns.Add("Rok Produkcji");
            dt1.Columns.Add("Data Przyjęcia");
            dt1.Columns.Add("Przebieg");
            dt1.Columns.Add("Firma");
            dt1.Columns.Add("Prywatny");
            ds.Tables.Add(dt1);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["Samochody"].NewRow();
                row1["Marka"] = r.Cells[0].Value;
                row1["Model"] = r.Cells[1].Value;
                row1["Nr. Rejestracyjny"] = r.Cells[2].Value;
                row1["Pojemność Silnika"] = r.Cells[3].Value;
                row1["VIN"] = r.Cells[4].Value;
                row1["Numer Silnika"] = r.Cells[5].Value;
                row1["Rok Produkcji"] = r.Cells[6].Value;
                row1["Data Przyjęcia"] = r.Cells[7].Value;
                row1["Przebieg"] = r.Cells[8].Value;
                row1["Firma"] = Convert.ToBoolean(r.Cells[9].Value);
                row1["Prywatny"] = Convert.ToBoolean(r.Cells[10].Value);
                ds.Tables["Samochody"].Rows.Add(row1);
            }
            ds.WriteXml("samochody.xml");
        }





        //
        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Auto_Load(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("samochody.xml");
                foreach (DataRow item in ds.Tables["Samochody"].Rows)
                {
                    int n = dataGridView1.Rows.Add();
                    dataGridView1.Rows[n].Cells[0].Value = item[0].ToString();
                    dataGridView1.Rows[n].Cells[1].Value = item[1].ToString();
                    dataGridView1.Rows[n].Cells[2].Value = item[2].ToString();
                    dataGridView1.Rows[n].Cells[3].Value = item[3].ToString();
                    dataGridView1.Rows[n].Cells[4].Value = item[4].ToString();
                    dataGridView1.Rows[n].Cells[5].Value = item[5].ToString();
                    dataGridView1.Rows[n].Cells[6].Value = item[6].ToString();
                    dataGridView1.Rows[n].Cells[7].Value = item[7].ToString();
                    dataGridView1.Rows[n].Cells[8].Value = item[8].ToString();
                    
                    if (Convert.ToBoolean(item[9]) == true)
                    {
                        dataGridView1.Rows[n].Cells[9].Value = Convert.ToBoolean(1);

                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[9].Value = Convert.ToBoolean(0);
                    }

                    if (Convert.ToBoolean(item[10]) == true)
                    {
                        dataGridView1.Rows[n].Cells[10].Value = Convert.ToBoolean(1);

                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[10].Value = Convert.ToBoolean(0);
                    }
                }
            }
            catch { }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if((textBox1.Text == " ")||(textBox2.Text == " ")|(textBox3.Text == " ")|(textBox4.Text == " ")|(textBox5.Text == " ")|(textBox6.Text == " ")|(textBox7.Text == " ")|(textBox8.Text == " ")|(textBox9.Text== " " )|(checkBox1.Checked== true)||checkBox2.Checked == true)
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[n].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[n].Cells[2].Value = textBox3.Text;
                dataGridView1.Rows[n].Cells[3].Value = textBox6.Text;
                dataGridView1.Rows[n].Cells[4].Value = textBox5.Text;
                dataGridView1.Rows[n].Cells[5].Value = textBox4.Text;
                dataGridView1.Rows[n].Cells[6].Value = textBox9.Text;
                dataGridView1.Rows[n].Cells[7].Value = textBox8.Text;
                dataGridView1.Rows[n].Cells[8].Value = textBox7.Text;
                dataGridView1.Rows[n].Cells[9].Value = checkBox1.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                dataGridView1.Rows[n].Cells[10].Value = checkBox2.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                textBox7.Text = " ";
                textBox8.Text = " ";
                textBox9.Text = " ";
                checkBox1.Checked = false;
                checkBox2.Checked = false;
                ZapisXml();
            }
        }
        private void dataGridView1_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            button2.Enabled = true;
            textBox1.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            textBox2.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            textBox3.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            textBox6.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            textBox5.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            textBox4.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            textBox9.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            textBox8.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            textBox7.Text = dataGridView1.SelectedRows[0].Cells[8].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[9].Value) == true)
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[10].Value) == true)
            {
                checkBox2.Checked = true;
            }
            else
            {
                checkBox2.Checked = false;
            }
            button1.Enabled = false;
            button3.Enabled = false;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if ((textBox1.Text == " ") | (textBox2.Text == " ") | (textBox3.Text == " ") | (textBox4.Text == " ") | (textBox5.Text == " ") | (textBox6.Text == " ") | (textBox7.Text == " ") | (textBox8.Text == " ") | (textBox9.Text == " "))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
                dataGridView1.Rows[0].Cells[0].Value = textBox1.Text;
                dataGridView1.Rows[0].Cells[1].Value = textBox2.Text;
                dataGridView1.Rows[0].Cells[2].Value = textBox3.Text;
                dataGridView1.Rows[0].Cells[3].Value = textBox6.Text;
                dataGridView1.Rows[0].Cells[4].Value = textBox5.Text;
                dataGridView1.Rows[0].Cells[5].Value = textBox4.Text;
                dataGridView1.Rows[0].Cells[6].Value = textBox9.Text;
                dataGridView1.Rows[0].Cells[7].Value = textBox8.Text;
                dataGridView1.Rows[0].Cells[8].Value = textBox7.Text;
                if (checkBox1.Checked == true)
                {
                    dataGridView1.SelectedRows[0].Cells[9].Value = 1;
                }
                else
                {
                    dataGridView1.SelectedRows[0].Cells[9].Value = 0;
                }
                if (checkBox2.Checked == true)
                {
                    dataGridView1.SelectedRows[0].Cells[10].Value = 1;
                }
                else
                {
                    dataGridView1.SelectedRows[0].Cells[10].Value = 0;
                }
                textBox1.Text = " ";
                textBox2.Text = " ";
                textBox3.Text = " ";
                textBox4.Text = " ";
                textBox5.Text = " ";
                textBox6.Text = " ";
                textBox7.Text = " ";
                textBox8.Text = " ";
                textBox9.Text = " ";
                button2.Enabled = false;
                ZapisXml();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Usun();
        }
        private void dataGridView1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Delete)
            {
                Usun();
            }
        }

    }

    
}

