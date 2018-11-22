using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenCheck
{
    public partial class FormaZaUnosStavkiNarudzbe : Form
    {
        Narudzba odabranaNarudzba;
        StavkeNarudzbe novaStavka;
        public FormaZaUnosStavkiNarudzbe(Narudzba novaNarudzba)
        {
            InitializeComponent();
            odabranaNarudzba = novaNarudzba;
        }
        public FormaZaUnosStavkiNarudzbe(StavkeNarudzbe odabranaStavka) {
            InitializeComponent();
            novaStavka = odabranaStavka;
            
        }
        
        /// <summary>
        /// Unos novih stavki narudzbe te provjera unesenih podataka
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actionFormaZaUnosNarudzbeDodajNarudzbu_Click(object sender, EventArgs e)
        {
            string odabrana = inputFormaZaUnosNarudzbeKlasaJaja.SelectedItem as string;
            int kolicina;
            double cijena = 0;
            using (var db = new ChickenCheckEntiteti())
            {
                if (novaStavka == null)
                {
                    if (int.TryParse(inputFormaZaUnosNarudzbeKolicinaDodanihJaja.Text, out kolicina) && double.TryParse(inputFormaZaUnosNarudzbeCijena.Text, out cijena) && kolicina > 0)
                    {
                        db.Narudzba.Attach(odabranaNarudzba);
                        StavkeNarudzbe stavka = new StavkeNarudzbe(kolicina, odabrana, cijena);
                        odabranaNarudzba.StavkeNarudzbe.Add(stavka);
                        db.SaveChanges();
                        this.Close();
                    }
                    else
                        MessageBox.Show("Unesite pravilne podatke!");
                }
                else {
                    db.StavkeNarudzbe.Attach(novaStavka);
                    novaStavka.cijena = double.Parse(inputFormaZaUnosNarudzbeCijena.Text);
                    novaStavka.kolicina = int.Parse(inputFormaZaUnosNarudzbeKolicinaDodanihJaja.Text);
                    db.SaveChanges();
                    this.Close();
                }
            }
            }

        private void actionObrisi_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormaZaUnosStavkiNarudzbe_Load_1(object sender, EventArgs e)
        {

            inputFormaZaUnosNarudzbeKlasaJaja.DataSource = StavkeNarudzbe.listaKlasa;
            if (novaStavka != null) {
                inputFormaZaUnosNarudzbeCijena.Text = novaStavka.cijena.ToString();
                inputFormaZaUnosNarudzbeKolicinaDodanihJaja.Text = novaStavka.kolicina.ToString();
            }
        }
    }
}
