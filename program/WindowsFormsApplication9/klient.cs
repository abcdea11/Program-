using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Xml.Serialization;
using System.Xml.Linq;
using System.Xml;


namespace WindowsFormsApplication9
{
    public partial class klient : Form
    {
        public klient()
        {
            InitializeComponent();
       
        }
        
        public void ZapisXml()
        {
            DataSet ds = new DataSet();
            DataTable dt1 = new DataTable();
            dt1.TableName = "Klient";
            dt1.Columns.Add("Imie");
            dt1.Columns.Add("Nazwisko");
            dt1.Columns.Add("Miasto");
            dt1.Columns.Add("Ulica");
            dt1.Columns.Add("Numer");
            dt1.Columns.Add("KodPocztowy");
            dt1.Columns.Add("Telefon");
            dt1.Columns.Add("Email");
            dt1.Columns.Add("Firma");
            ds.Tables.Add(dt1);
            foreach (DataGridViewRow r in dataGridView1.Rows)
            {
                DataRow row1 = ds.Tables["Klient"].NewRow();
                row1["Imie"] = r.Cells[0].Value;
                row1["Nazwisko"] = r.Cells[1].Value;
                row1["Miasto"] = r.Cells[2].Value;
                row1["Ulica"] = r.Cells[3].Value;
                row1["Numer"] = r.Cells[4].Value;
                row1["KodPocztowy"] = r.Cells[5].Value;
                row1["Telefon"] = r.Cells[6].Value;
                row1["Email"] = r.Cells[7].Value;


                row1["Firma"] = Convert.ToBoolean(r.Cells[8].Value);
                ds.Tables["Klient"].Rows.Add(row1);
            }
            ds.WriteXml("klient.xml");
        }


        private void button1_Click(object sender, EventArgs e)
        {

            if ((txtImie.Text == "") | (txtNazwisko.Text == "") | (txtMiasto.Text == "") |
                (txtUlica.Text == "") | (txtNumer.Text == "") | (txtKodPocztowy.Text == "") |
                (txtTelefon.Text == "") | (txtEmail.Text == ""))
            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
               
            
            else
            {
                int n = dataGridView1.Rows.Add();
                dataGridView1.Rows[n].Cells[0].Value = txtImie.Text;
                dataGridView1.Rows[n].Cells[1].Value = txtNazwisko.Text;
                dataGridView1.Rows[n].Cells[2].Value = txtMiasto.Text;
                dataGridView1.Rows[n].Cells[3].Value = txtUlica.Text;
                dataGridView1.Rows[n].Cells[4].Value = txtNumer.Text;
                dataGridView1.Rows[n].Cells[5].Value = txtKodPocztowy.Text;
                dataGridView1.Rows[n].Cells[6].Value = txtTelefon.Text;
                dataGridView1.Rows[n].Cells[7].Value = txtEmail.Text;


                dataGridView1.Rows[n].Cells[8].Value = checkBox1.Checked == true ? Convert.ToBoolean(1) : Convert.ToBoolean(0);
                txtImie.Text = "";
                txtNazwisko.Text = "";
                txtMiasto.Text = "";
                txtUlica.Text = "";
                txtNumer.Text = "";
                txtKodPocztowy.Text = "";
                txtTelefon.Text = "";
                txtEmail.Text = "";
                ZapisXml();
            }
           

        }
        private void button5_Click(object sender, EventArgs e)
        {
         
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

      
        private void button3_Click(object sender, EventArgs e)
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



        private void klient_Load(object sender, EventArgs e)
        {
          
            DataSet ds = new DataSet();
            try
            {
                ds.ReadXml("klient.xml");
                foreach (DataRow item in ds.Tables["Klient"].Rows)
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

                    if (Convert.ToBoolean(item[8]) == true)
                    {
                        dataGridView1.Rows[n].Cells[8].Value = Convert.ToBoolean(1);

                    }
                    else
                    {
                        dataGridView1.Rows[n].Cells[8].Value = Convert.ToBoolean(0);
                    }
                }
            }
            catch { }      
        }



        private void button2_Click(object sender, EventArgs e)
        {
            if ((txtImie.Text == "") | (txtNazwisko.Text == "") | (txtMiasto.Text == "") |
                 (txtUlica.Text == "") | (txtNumer.Text == "") | (txtKodPocztowy.Text == "") |
                 (txtTelefon.Text == "") | (txtEmail.Text == ""))

            {
                MessageBox.Show("Uzupełnij wszystkie pola!");
            }
            else
            {
                button1.Enabled = true;
                button3.Enabled = true;
                dataGridView1.SelectedRows[0].Cells[0].Value = txtImie.Text;
                dataGridView1.SelectedRows[0].Cells[1].Value = txtNazwisko.Text;
                dataGridView1.SelectedRows[0].Cells[2].Value = txtMiasto.Text;
                dataGridView1.SelectedRows[0].Cells[3].Value = txtUlica.Text;
                dataGridView1.SelectedRows[0].Cells[4].Value = txtNumer.Text;
                dataGridView1.SelectedRows[0].Cells[5].Value = txtKodPocztowy.Text;
                dataGridView1.SelectedRows[0].Cells[6].Value = txtTelefon.Text;
                dataGridView1.SelectedRows[0].Cells[7].Value = txtEmail.Text;
                if (checkBox1.Checked == true)
                {
                    dataGridView1.SelectedRows[0].Cells[8].Value = 1;
                }
                else
                {
                    dataGridView1.SelectedRows[0].Cells[8].Value = 0;
                }
                txtImie.Text = "";
                txtNazwisko.Text = "";
                txtMiasto.Text = "";
                txtUlica.Text = "";
                txtNumer.Text = "";
                txtKodPocztowy.Text = "";
                txtTelefon.Text = "";
                txtEmail.Text = "";
                button2.Enabled = false;
                ZapisXml();
            }
        }



        private void dataGridView1_CellMouseDoubleClick(object sender, DataGridViewCellMouseEventArgs e)
        {
            button2.Enabled = true;
            txtImie.Text = dataGridView1.SelectedRows[0].Cells[0].Value.ToString();
            txtNazwisko.Text = dataGridView1.SelectedRows[0].Cells[1].Value.ToString();
            txtMiasto.Text = dataGridView1.SelectedRows[0].Cells[2].Value.ToString();
            txtUlica.Text = dataGridView1.SelectedRows[0].Cells[3].Value.ToString();
            txtNumer.Text = dataGridView1.SelectedRows[0].Cells[4].Value.ToString();
            txtKodPocztowy.Text = dataGridView1.SelectedRows[0].Cells[5].Value.ToString();
            txtTelefon.Text = dataGridView1.SelectedRows[0].Cells[6].Value.ToString();
            txtEmail.Text = dataGridView1.SelectedRows[0].Cells[7].Value.ToString();
            if (Convert.ToBoolean(dataGridView1.SelectedRows[0].Cells[8].Value = 1))
            {
                checkBox1.Checked = true;
            }
            else
            {
                checkBox1.Checked = false;
            }
            button1.Enabled = false;
            button3.Enabled = false;
        }



        private void button4_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
