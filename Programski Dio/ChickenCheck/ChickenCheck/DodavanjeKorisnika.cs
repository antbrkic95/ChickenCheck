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
    public partial class FormaDodavanjeKorisnika : Form
    {
        #region atributi i svojstva
        Korisnik noviKorisnik;
        Korisnik korisnikZaEdit;

        //BindingList<Funkcionalnost> listaFunkcionalnosti;
        BindingList<Funkcionalnost> ovlastiKorisnika;
        BindingList<Funkcionalnost> listaFunkcionalnosti;
        IEnumerable<Funkcionalnost> listaFunkcionalnosti2;
        #endregion

        #region konstruktori
        /// <summary>
        /// Konstruktor forme za dodavanje novog korisnika
        /// </summary>
        public FormaDodavanjeKorisnika()
        {
            InitializeComponent();
            noviKorisnik = new Korisnik();
            ovlastiKorisnika = new BindingList<Funkcionalnost>();
            DohvatiSveFunkcionalnosti();
            OsvjeziPopisDostupnihFunkcionalnosti();
        }
        /// <summary>
        /// Konstruktor forme za editiranje postojecih korisnika
        /// </summary>
        /// <param name="proslijedeniKorisnik"></param>
        public FormaDodavanjeKorisnika(Korisnik proslijedeniKorisnik)
        {
            InitializeComponent();
            
            //Ovdje se proslijedeniKorisnik koristi 2 puta jer su nam potrebni podaci prije i nakon uredjivanja korisnickih podataka.
            noviKorisnik = proslijedeniKorisnik;
            korisnikZaEdit = proslijedeniKorisnik;

            //postavljanje vrijednosti textboxa na vrijednosti odabranog korisnika
            inputFormaDodavanjeKorisnikaIme.Text = noviKorisnik.ime;
            inputFormaDodavanjeKorisnikaPrezime.Text= noviKorisnik.prezime;
            inputFormaDodavanjeKorisnikaLozinka.Text = noviKorisnik.lozinka;
            inputFormaDodavanjeKorisnikaKorime.Text = noviKorisnik.korisnickoIme;
            inputFormaDodavanjeKorisnikaLozinka.Text = noviKorisnik.lozinka;
            inputFormaDodavanjeKorisnikaMail.Text = noviKorisnik.email;
            inputFormaDodavanjeKorisnikaTelefon.Text = noviKorisnik.telefon;

            //korisnicke ovlasti koje korisnik vec ima
            ovlastiKorisnika = new BindingList<Funkcionalnost>(noviKorisnik.Funkcionalnost.ToList());
            OsvjeziPopisKorisnikovihFunkcionalnosti();
            //dohvacanje i ispis korisnickih ovlasti koje moze imati
            OdrediDostupneFunkcionalnosti();
            OsvjeziPopisDostupnihFunkcionalnosti();
        }
        #endregion
        #region Metode
        /// <summary>
        /// Dohvaca sve dostupne ovlasti koje se mogu omogućiti korisniku
        /// </summary>
        private void DohvatiSveFunkcionalnosti()
        {
            listaFunkcionalnosti = Funkcionalnost.VratiListuSvihFunkcionalnosti();
        }
        /// <summary>
        /// Iz popisa svih funkcionalnosti uklanja one koje korisnik već posjeduje.
        /// </summary>
        private void OdrediDostupneFunkcionalnosti()
        {

            var pomocnaListaSvihFunkcionalnosti = Funkcionalnost.VratiListuSvihFunkcionalnosti();
            
            listaFunkcionalnosti2 = pomocnaListaSvihFunkcionalnosti.Except(ovlastiKorisnika, new KomparatorJednakostiFunkcionalnosti()).ToList();
            listaFunkcionalnosti = new BindingList<Funkcionalnost>(listaFunkcionalnosti2.ToList());

        }
        /// <summary>
        /// Osvjezava prikaz korisnikovih ovlasti
        /// </summary>
        private void OsvjeziPopisKorisnikovihFunkcionalnosti()
        {
            inputFormaDodavanjeKorisnikaOvlastiKorisnika.DataSource = ovlastiKorisnika;
        }
        /// <summary>
        /// Daje popis svih funkcionalnosti koji se prikazuje u listboxu
        /// </summary>
        private void OsvjeziPopisDostupnihFunkcionalnosti()
        {
            outputFormaDodavanjeKorisnikaListaDostupnihOvlasti.DataSource = listaFunkcionalnosti;
        }
        #endregion

        #region Eventi
        #region upravljanje ovlastima korisnika
        private void actionFormaDodavanjeKorisnikaDodajOvlast_Click(object sender, EventArgs e)
        {
            Funkcionalnost odabranaFunkcionalnost = outputFormaDodavanjeKorisnikaListaDostupnihOvlasti.SelectedItem as Funkcionalnost;
            if (odabranaFunkcionalnost != null)
            {
                ovlastiKorisnika.Add(odabranaFunkcionalnost);
                listaFunkcionalnosti.Remove(odabranaFunkcionalnost);
                OsvjeziPopisKorisnikovihFunkcionalnosti();
                OsvjeziPopisDostupnihFunkcionalnosti();
            }

        }
        private void actionFormaDodavanjeKorisnikaOduzmiOvlast_Click(object sender, EventArgs e)
        {
            Funkcionalnost odabranaFunkcionalnost = inputFormaDodavanjeKorisnikaOvlastiKorisnika.SelectedItem as Funkcionalnost;
            if (odabranaFunkcionalnost != null)
            {
                listaFunkcionalnosti.Add(odabranaFunkcionalnost);
                ovlastiKorisnika.Remove(odabranaFunkcionalnost);
                OsvjeziPopisKorisnikovihFunkcionalnosti();
                OsvjeziPopisDostupnihFunkcionalnosti();
            }

        }
        #endregion
        private void actionFormaDodavanjeKorisnikaDodajKorisnika_Click(object sender, EventArgs e)
        {
            string unesenoIme = inputFormaDodavanjeKorisnikaIme.Text;
            string unesenoPrezime = inputFormaDodavanjeKorisnikaPrezime.Text;
            string unesenoKorisnickoIme = inputFormaDodavanjeKorisnikaKorime.Text;
            string unesenaLozinka = inputFormaDodavanjeKorisnikaLozinka.Text;
            string unesenaEmailAdresa = inputFormaDodavanjeKorisnikaMail.Text;
            string uneseniTelefonskiBroj = inputFormaDodavanjeKorisnikaTelefon.Text;

            //Provjera unesenih podataka
            if (!string.IsNullOrWhiteSpace(unesenoIme) && !string.IsNullOrWhiteSpace(unesenoPrezime) && !string.IsNullOrWhiteSpace(unesenoKorisnickoIme) && !string.IsNullOrWhiteSpace(unesenaLozinka))
            {
                noviKorisnik.ime = unesenoIme;
                noviKorisnik.prezime = unesenoPrezime;
                noviKorisnik.korisnickoIme = unesenoKorisnickoIme;
                noviKorisnik.lozinka = unesenaLozinka;
                noviKorisnik.email = unesenaEmailAdresa;
                noviKorisnik.telefon = uneseniTelefonskiBroj;
                noviKorisnik.zapisNeaktivan = false;
                noviKorisnik.Funkcionalnost = ovlastiKorisnika;

                //Dodavanje novog korisnika ili uredjivanje postojeceg
                if (korisnikZaEdit != null)
                {
                    noviKorisnik.DodajPostojecegKorisnikaUBazu(korisnikZaEdit, noviKorisnik);
                }
                else
                {
                    noviKorisnik.DodajNovogKorisnikaUBazu(noviKorisnik);
                }
                this.Close();
            }



        }
        #endregion


    }
}
