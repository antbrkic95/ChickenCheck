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
    public partial class FormaZaUnosJaja : Form
        
    {
        private Korisnik noviKorisnik;
        public FormaZaUnosJaja(Korisnik prijavljeniKorisnik)
        {
            InitializeComponent();
            noviKorisnik = prijavljeniKorisnik;
          

        }

        private void FormaZaUnosJaja_Load(object sender, EventArgs e)
        {
            inputFormaZaUnosJajaKlasaJaja.DataSource = Jaja.listaKlasa;
        }
        /// <summary>
        /// Unos novih jaja na temelju aktivnog turnusa
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actionFormaZaUnosJajaDodajJaja_Click(object sender, EventArgs e)
        {
            using (var kontekst = new ChickenCheckEntiteti())
            {
                KokosiTurnus odabraniTurnus = new KokosiTurnus();
                odabraniTurnus=odabraniTurnus.DohvatiAktivanTurnus();
                DateTime datum = DateTime.Now;
                int kolicina;
                string klasa = inputFormaZaUnosJajaKlasaJaja.SelectedItem as string;
                if (int.TryParse(inputFormaZaUnosJajaKolicinaDodanihJaja.Text, out kolicina) && kolicina>0)
                {
                    
                    Jaja unesena = new Jaja(datum, kolicina, klasa);
                    unesena.DodajJajaUBazu(odabraniTurnus);
                    UnositeljJaja noviUnositelj = new UnositeljJaja();
                    noviUnositelj.UnesiAzuriranjeJaja(unesena,noviKorisnik);

                }
                else
                {
                    MessageBox.Show("Morate unijeti broj!");

                }
                
            }
            this.Close();
        }
    }
}
