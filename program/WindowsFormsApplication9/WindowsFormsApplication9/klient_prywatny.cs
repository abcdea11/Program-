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
    public partial class klient_prywatny : Form
    {
        public klient_prywatny()
        {
            InitializeComponent();
            
        }

        private void addToXml(bool value)
        {
            List<klientprywatny> klienci = new List<klientprywatny>();
              klienci.Add(new klientprywatny() { Imie = txtImie.Text, Nazwisko = txtNazwisko.Text, miasto = txtMiasto.Text, ulica=txtUlica.Text,
                                                kodpocztowy=txtKodPocztowy.Text, telefon=txtTelefon.Text, email=txtEmail.Text, numer=txtNumer.Text});

            
                        XDocument doc = XDocument.Load("Osoby.xml");
            var osoba =
              from klient in klienci
              orderby klient.Nazwisko, klient.Imie
              select new XElement("osoba",
                   new XElement("imie", klient.Imie),
                        new XElement("nazwisko", klient.Nazwisko),
                        new XElement("miasto", klient.miasto),
                        new XElement("ulica", klient.ulica),
                        new XElement("kodpocztowy", klient.kodpocztowy),
                        new XElement("telefon", klient.telefon),
                        new XElement("email", klient.email),
                        new XElement("numer", klient.numer)
                );                                                             
                        
                        doc.Root.Element("prywatni").Add(osoba);
                        doc.Save("Osoby.xml");
            
        }

        private void klient(bool value)
        {
            List<klientprywatny> klienci = new List<klientprywatny>();
            klienci.Add(new klientprywatny() { Imie = txtImie.Text, Nazwisko = txtNazwisko.Text, miasto = txtMiasto.Text, ulica=txtUlica.Text,
                                                kodpocztowy=txtKodPocztowy.Text, telefon=txtTelefon.Text, email=txtEmail.Text, numer=txtNumer.Text});



            XDocument xml = new XDocument(
                new XDeclaration("1.0", "utf-8", "yes"),
                new XComment("Lista osób z kolekcji"),
                new XElement("Klienci",
                   new XElement("prywatni",
                    from klient in klienci
                    orderby klient.Nazwisko, klient.Imie
                    select new XElement("osoba",
                        new XElement("imie", klient.Imie),
                        new XElement("nazwisko", klient.Nazwisko),
                        new XElement("miasto", klient.miasto),
                        new XElement("ulica", klient.ulica),
                        new XElement("kodpocztowy", klient.kodpocztowy),
                        new XElement("telefon", klient.telefon),
                        new XElement("email", klient.email),
                        new XElement("numer", klient.numer)





                        )
                    )
                    )
                );

            xml.Save("Osoby.xml");

        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (File.Exists("Osoby.xml") == true)
            {
                addToXml(true);
            }
            else
            {
                klient(true);
            }


        }
        private void button5_Click(object sender, EventArgs e)
        {
            DataSet ds = new DataSet();
            ds.ReadXml(@"C: \Users\bob\Desktop\WindowsFormsApplication9 - master\WindowsFormsApplication9\bin\Debug\Osoby.xml");
            dataGridView1.DataSource = ds.Tables[1];

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {
            
            // Wusyniecie z data grida wybranej pozycji 
            List<int> indeksyZaznaczonychWierszy = new List<int>();
            int Licznik = 0;
            while (Licznik < dataGridView1.SelectedRows.Count)
            {
                indeksyZaznaczonychWierszy.Add(
                dataGridView1.Rows.IndexOf(dataGridView1.SelectedRows[Licznik])
                 );
                Licznik++;
            }
            indeksyZaznaczonychWierszy.Sort();
            Licznik = indeksyZaznaczonychWierszy.Count - 1;
            while (Licznik > -1)
            {
                dataGridView1.Rows.RemoveAt(indeksyZaznaczonychWierszy[Licznik]);
                Licznik--;
            }
            
            
            //

        }
    }
}
