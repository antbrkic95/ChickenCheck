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
    public partial class LoginEkran : Form
    {
        #region svojstva i atributi
        public Korisnik prijavljeniKorisnik;
        #endregion

        public LoginEkran()
        {
            InitializeComponent();
        }
        #region metode

        /// <summary>
        /// Metoda za izmjenu statusa na formi
        /// </summary>
        /// <param name="opisGreske">Opis koji će se ispisati na formi</param>
        private void PromijeniGresku(string opisGreske)
        {
            outputLoginEkranGreskePrijavljivanja.Text = opisGreske;
        }

        #endregion

        #region eventi
        private void actionLoginEkranPrijava_Click(object sender, EventArgs e)
        {

            string unesenoKorisnickoIme = inputLoginEkranKorisnickoIme.Text;
            string unesenaKorisnickaLozinka = inputLoginEkranLozinka.Text;

            prijavljeniKorisnik = new Korisnik();
            try
            {
                prijavljeniKorisnik = prijavljeniKorisnik.ProvjeriKorisnika(unesenoKorisnickoIme, unesenaKorisnickaLozinka);
            }
            catch (Exception iznimka)
            {
                MessageBox.Show("Nije moguće uspostaviti vezu s bazom podataka. Detalji:"+iznimka.Message);
            }
            if (prijavljeniKorisnik == null)
            {
                PromijeniGresku("Neispravno korisničko ime ili lozinka");
            }
            else
            {
                DialogResult = DialogResult.OK;
                this.Close();
            }
        }
        #endregion
    }
}
