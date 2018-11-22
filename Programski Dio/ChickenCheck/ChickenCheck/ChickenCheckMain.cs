using LiveCharts;
using LiveCharts.Wpf;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ChickenCheck
{
    public partial class ChickenCheckMain : Form
    {
        #region svojstva i atributi

        public Korisnik prijavljeniKorisnik;
        public Sirovina prikazSirovina;
        public Jaja prikazJaja;
        public Narudzba novaNarudzba;
        public StavkeNarudzbe noveStavke;
        public StanjeNarudzbe novoStanje;
        public KokosiTurnus prikazTurnusa;
        public Narudzba novaProdaja;
        public StavkeNarudzbe prodaneStavke;

        #region svojstva za grafove
        public DohvacanjePodataka modulZaDohvatPodatakaGrafa;
        #endregion

        #endregion
        public ChickenCheckMain()
        {
            LoginEkran ekranZaPrijavu = new LoginEkran();
            ekranZaPrijavu.ShowDialog();
            prijavljeniKorisnik = ekranZaPrijavu.prijavljeniKorisnik;
            if (ekranZaPrijavu.DialogResult == DialogResult.Cancel)
            {
                System.Environment.Exit(1);
            }
            InitializeComponent();
            //Prosljeđivanje objekta klase korisnik iz ekrana za prijavu - podaci o korisniku koji trenutno koristi apk.
            SakrijGumbe();
            OmoguciGumbeZaKojeKorisnikImaOvlasti(prijavljeniKorisnik);    
            //Postavke tabcontrol objekta, skrivanje tabova i povećanje preko cijelog ekrana
            outputKontrolaProzora.Appearance = TabAppearance.FlatButtons;
            outputKontrolaProzora.ItemSize = new Size(0, 1);
            outputKontrolaProzora.SizeMode = TabSizeMode.Fixed;
            modulZaDohvatPodatakaGrafa = new DohvacanjePodataka();
            AktivirajPocetniTabKorisnika(prijavljeniKorisnik);

        }

        #region Metode
        
        /// <summary>
        /// Resetira izgled svih stavki izbornika na istu boju
        /// </summary>
        private void VratiBojeSvihElemenataIzbornika()
        {
            actionOtvoriEvidencijuJaja.BackColor = Color.BurlyWood;
            actionOtvoriProdajuINarudzbu.BackColor = Color.BurlyWood;
            actionOtvoriSirovine.BackColor = Color.BurlyWood;
            actionOtvoriEvidencijuKokosi.BackColor = Color.BurlyWood;
            actionOtvoriUpravljanjeKorisnicima.BackColor = Color.BurlyWood;
        }

        /// <summary>
        /// Mijenja boju gumba u predodređenu boju (Peru)
        /// </summary>
        /// <param name="gumb">Objekt klase gumb kojem se mijenja boja</param>
        private void PromijeniBojuGumba(Button gumb)
        {
            gumb.BackColor = Color.Peru;
        }

        /// <summary>
        /// Sakriva gumbe za sve funkcionalnosti
        /// </summary>
        private void SakrijGumbe()
        {
            actionOtvoriEvidencijuJaja.Visible = false;
            actionOtvoriProdajuINarudzbu.Visible = false;
            actionOtvoriSirovine.Visible = false;
            actionOtvoriEvidencijuKokosi.Visible = false;
            actionOtvoriUpravljanjeKorisnicima.Visible = false;
        }

        /// <summary>
        /// Omogućava korištenje funkcionalnosti sukladno korisnikovim ovlastima.
        /// </summary>
        /// <param name="korisnik"> Korisnik prema kojem se omogućava korištenje ovlasti</param>
        private void OmoguciGumbeZaKojeKorisnikImaOvlasti(Korisnik korisnik)
        {
            using(ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                kontekstBazePodataka.Korisnik.Attach(korisnik);
                foreach (var funkcionalnost in korisnik.Funkcionalnost)
                {
                    if (funkcionalnost.nazivFunkcionalnosti == actionOtvoriEvidencijuJaja.Text)
                    {
                        actionOtvoriEvidencijuJaja.Visible = true;
                    }

                    else if (funkcionalnost.nazivFunkcionalnosti == actionOtvoriProdajuINarudzbu.Text)
                    {
                        actionOtvoriProdajuINarudzbu.Visible = true;
                    }
                    
                    else if (funkcionalnost.nazivFunkcionalnosti == actionOtvoriSirovine.Text)
                    {
                        actionOtvoriSirovine.Visible = true;
                    }
                       
                    else if (funkcionalnost.nazivFunkcionalnosti == actionOtvoriEvidencijuKokosi.Text)
                    {
                        actionOtvoriEvidencijuKokosi.Visible = true;
                    }
                        
                    else if (funkcionalnost.nazivFunkcionalnosti == actionOtvoriUpravljanjeKorisnicima.Text)
                    {
                        actionOtvoriUpravljanjeKorisnicima.Visible = true;
                    }
                        
                }
            }

        }

        private void OsvjeziOutputOvlasti(List<Funkcionalnost> listaFunkcionalnosti)
        {
            outputOvlasti.DataSource = listaFunkcionalnosti;
        }

        private void OsvjeziNaruzdbe()
        {
            novaNarudzba = new Narudzba();
            //Reverse() se koristi kako bi lista bila sortirana tako da najnoviji zapisi budu na vrhu
            narudzbaBindingSource.DataSource = novaNarudzba.DohvatiNarudzbe().Reverse();
            IscrtajLinijskiGrafProdaje();
        }
       
        private void OsvjeziStavke(Narudzba nova)
        {
            noveStavke = new StavkeNarudzbe();
            stavkeNarudzbeBindingSource.DataSource = noveStavke.PrikaziStavke(nova);

        }

        private void OsvjeziProdaneStavke(Narudzba nova)
        {

            prodaneStavke = new StavkeNarudzbe();
            stavkeNarudzbeBindingSource1.DataSource = prodaneStavke.PrikaziStavke(nova);
        }

        private void OsvjeziProdaju()
        {

            novaProdaja = new Narudzba();
            //Reverse() se koristi kako bi lista bila sortirana tako da najnoviji zapisi budu na vrhu
            narudzbaBindingSource1.DataSource = novaProdaja.DohvatiProdaju().Reverse();
            IscrtajLinijskiGrafProdaje();
        }

        private void OsvjeziListuKorisnika()
        {
            korisnikBindingSource.DataSource = prijavljeniKorisnik.VratiListuKorisnika();
        }

        private void OsvjeziUnesenaJaja()
        {
            prikazJaja = new Jaja();
            KokosiTurnus odabraniTurnus = new KokosiTurnus();
            odabraniTurnus = odabraniTurnus.DohvatiAktivanTurnus();
            //Reverse() se koristi kako bi lista bila sortirana tako da najnoviji zapisi budu na vrhu
            jajaBindingSource.DataSource = prikazJaja.VratiListuJaja(odabraniTurnus).Reverse();
            OsvjeziUkupnoStanjeJaja(odabraniTurnus);
        }

        private void OsvjeziUkupnoStanjeJaja(KokosiTurnus odabraniTurnus)
        {
            int kolicinaS = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "S");
            int kolicinaM = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "M");
            int kolicinaL = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "L");
            int kolicinaXL = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "XL");
            DohvacanjePodataka noviPodaci = new DohvacanjePodataka();
            int kolicinaProdanihS = noviPodaci.dohvatiProdanaJajaPoKlasi("S");
            int kolicinaProdanihM = noviPodaci.dohvatiProdanaJajaPoKlasi("M");
            int kolicinaProdanihL = noviPodaci.dohvatiProdanaJajaPoKlasi("L");
            int kolicinaProdanihXL = noviPodaci.dohvatiProdanaJajaPoKlasi("XL");

            int rezultatS = kolicinaS - kolicinaProdanihS;
            int rezultatM = kolicinaM - kolicinaProdanihM;
            int rezultatL = kolicinaL - kolicinaProdanihL;
            int rezultatXL = kolicinaXL - kolicinaProdanihXL;
            if (rezultatS < 0) rezultatS = 0;
            if (rezultatM < 0) rezultatM = 0;
            if (rezultatL < 0) rezultatL = 0;
            if (rezultatXL < 0) rezultatXL = 0;

            outputStanjeSkladišta.Text = "Trenutno stanje skladišta: " + (rezultatXL) + " XL, " + (rezultatL) + " L, " + (rezultatM) + " M ," + (rezultatS) + " S";
            outputStanjeSkladista2.Text = "Trenutno stanje skladišta: " + (rezultatXL) + " XL, " + (rezultatL) + " L, " + (rezultatM) + " M ," + (rezultatS) + " S";
        }

        private void OsvjeziListuSirovina()
        {
            prikazSirovina = new Sirovina();
            BindingList<Sirovina> listaSirovina = prikazSirovina.ispisiSirovine();
            sirovinaBindingSource.DataSource = listaSirovina;
        }

        private void OsvjeziStanja() {
            novoStanje = new StanjeNarudzbe();
            BindingList<StanjeNarudzbe> listaStanja = novoStanje.PrikaziStanja();
        }

        private void OsjveziListuBaterijaKaveza()
        {
            prikazTurnusa = new KokosiTurnus();
            prikazTurnusa = prikazTurnusa.DohvatiAktivanTurnus();

            BindingList<BaterijeKaveza> prikazBaterijeKaveza = prikazTurnusa.ispisSvihBaterija(prikazTurnusa);
            baterijeKavezaBindingSource.DataSource = prikazBaterijeKaveza;

        }
        
        private void OsvjeziListuCijepljenja()
        {
            Cijepljenje novoCijepljenje = new Cijepljenje();
            prikazTurnusa = new KokosiTurnus();
            prikazTurnusa = prikazTurnusa.DohvatiAktivanTurnus();
            outputIzvrsenaCijepljenja.DataSource = novoCijepljenje.VratiListuCijepljenja(prikazTurnusa.idTurnusa);
        }

        private void OsvjeziListuDostupnihCijepljenja()
        {
            Cjepivo privremenoCjepivo = new Cjepivo();
            outputDostupnaCjepiva.DataSource = privremenoCjepivo.ispisiDostupnaCjepiva();
        }

        public void OsvjeziZapise()
        {
            DohvacanjePodataka noviPodaci = new DohvacanjePodataka();
            outputStanjeProdanih.Text = "Trenutno stanje prodanih jaja: " + noviPodaci.dohvatiProdanaJajaPoKlasi("XL").ToString() + " XL, " + noviPodaci.dohvatiProdanaJajaPoKlasi("L").ToString() + " L, " + noviPodaci.dohvatiProdanaJajaPoKlasi("M").ToString() + " M ," + noviPodaci.dohvatiProdanaJajaPoKlasi("S").ToString() + " S";
        }

        private void OsvjeziKupce()
        {
            Kupac noviKupac = new Kupac();
            outputPrikazKupaca.DataSource = noviKupac.DohvatiKupce();
        }

        private void AktivirajPocetniTabKorisnika (Korisnik korisnik)
        {
            try
            {
                Funkcionalnost prvaFunkcionalnost = korisnik.vratiListuOvlastiKorisnika().First();

                if (prvaFunkcionalnost.nazivFunkcionalnosti == actionOtvoriEvidencijuJaja.Text)
                {
                    outputKontrolaProzora.SelectedTab = formaEvidencijaJaja;
                    VratiBojeSvihElemenataIzbornika();
                    PromijeniBojuGumba(actionOtvoriEvidencijuJaja);
                    OsvjeziUnesenaJaja();
                    IscrtajLinijskiGrafJaja();
                }

                else if (prvaFunkcionalnost.nazivFunkcionalnosti == actionOtvoriProdajuINarudzbu.Text)
                {
                    outputKontrolaProzora.SelectedTab = outputKontaktKupca;
                    VratiBojeSvihElemenataIzbornika();
                    PromijeniBojuGumba(actionOtvoriProdajuINarudzbu);
                    OsvjeziNaruzdbe();
                    OsvjeziProdaju();
                    IscrtajLinijskiGrafProdaje();
                    OsvjeziKupce();
                    OsvjeziZapise();
                }

                else if (prvaFunkcionalnost.nazivFunkcionalnosti == actionOtvoriSirovine.Text)
                {
                    outputKontrolaProzora.SelectedTab = formaEvidencijaSirovina;
                    VratiBojeSvihElemenataIzbornika();
                    PromijeniBojuGumba(actionOtvoriSirovine);
                    OsvjeziListuSirovina();
                    IscrtajGrafSirovina();
                }

                else if (prvaFunkcionalnost.nazivFunkcionalnosti == actionOtvoriEvidencijuKokosi.Text)
                {
                    outputKontrolaProzora.SelectedTab = formaEvidencijaKokosi;
                    VratiBojeSvihElemenataIzbornika();
                    PromijeniBojuGumba(actionOtvoriEvidencijuKokosi);
                    OsjveziListuBaterijaKaveza();
                    IscrtajStupcastiGrafUginulih();
                    OsvjeziListuCijepljenja();
                    OsvjeziListuDostupnihCijepljenja();
                }

                else if (prvaFunkcionalnost.nazivFunkcionalnosti == actionOtvoriUpravljanjeKorisnicima.Text)
                {
                    outputKontrolaProzora.SelectedTab = formaKorisnik;
                    VratiBojeSvihElemenataIzbornika();
                    PromijeniBojuGumba(actionOtvoriUpravljanjeKorisnicima);
                    OsvjeziListuKorisnika();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show("Nije moguće jer nemate funkcionalnosti" + ex.Message);
            }

        }

        #region metode za grafove
        /// <summary>
        /// Ova metoda dohvaća podatke te iscrtava piechart
        /// </summary>
        private void IscrtajGrafSirovina()
        {
            BindingList<ZapisGrafa> stanjeSirovina;
            stanjeSirovina = modulZaDohvatPodatakaGrafa.VratiStanjaSirovina();

            SeriesCollection grafikonPita = new SeriesCollection();
            foreach (var item in stanjeSirovina)
            {
                PieSeries sirovinaGrafikona = new PieSeries
                {
                    Title = item.Naziv,
                    Values = new ChartValues<decimal> { item.BrojcanaVrijednost }
                };
                grafikonPita.Add(sirovinaGrafikona);
            }
            outputStanjeSirovinaVizualizacija.Series = grafikonPita;
            outputStanjeSirovinaVizualizacija.LegendLocation = LegendLocation.Bottom;
        }

        /// <summary>
        /// Ova metoda u skup podataka koji se iscrtavaju na linijskom grafu dodaje količinu 0 za one datume kada zapisa nema
        /// </summary>
        /// <param name="linija">serija podataka za liniju koju je potrebno prepraviti</param>
        /// <param name="datumiUnosa">lista svih dostupnih datuma u grafu</param>
        /// <param name="rezultatUpita">lista dohvacenih zapisa</param>
        private void UrediLinijePoDatumima(LineSeries linija, BindingList<DateTime> datumiUnosa, BindingList<ZapisGrafa> rezultatUpita)
        {
            
            foreach (var datumUnosa in datumiUnosa)
            {
                bool nemaZapisaZaDatum = true;
                foreach (var zapis in rezultatUpita)
                {
                    if (zapis.Dan == datumUnosa)
                    {
                        nemaZapisaZaDatum = false;
                        linija.Values.Add(zapis.BrojcanaVrijednost);
                    }

                }
                if (nemaZapisaZaDatum)
                {
                    int nula = 0;
                    linija.Values.Add(nula);
                }
            }
        }
        /// <summary>
        /// Ova metoda dohvaća podatke te zatim iscrtava linijski graf.
        /// </summary>
        private void IscrtajLinijskiGrafJaja()
        {
            //dohvat podataka
            BindingList<ZapisGrafa> rezultatUpitaS;
            BindingList<ZapisGrafa> rezultatUpitaM;
            BindingList<ZapisGrafa> rezultatUpitaL;
            BindingList<ZapisGrafa> rezultatUpitaXL;
            BindingList<DateTime> sviDatumiUnosa;
            KokosiTurnus trenutniTurnus = new KokosiTurnus();
            trenutniTurnus = trenutniTurnus.DohvatiAktivanTurnus();

            rezultatUpitaS = modulZaDohvatPodatakaGrafa.VratiBrojJajaPoKlasama("S",trenutniTurnus.idTurnusa);
            rezultatUpitaM = modulZaDohvatPodatakaGrafa.VratiBrojJajaPoKlasama("M",trenutniTurnus.idTurnusa);
            rezultatUpitaL = modulZaDohvatPodatakaGrafa.VratiBrojJajaPoKlasama("L",trenutniTurnus.idTurnusa);
            rezultatUpitaXL = modulZaDohvatPodatakaGrafa.VratiBrojJajaPoKlasama("XL",trenutniTurnus.idTurnusa);
            sviDatumiUnosa = modulZaDohvatPodatakaGrafa.VratiDatumeUnosaJaja(trenutniTurnus.idTurnusa);

            //dodavanje osi
            Axis os = new Axis()
            {
                Separator = new Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }

            };
            os.Labels = new List<string>();

            //učitavanje podataka u serije grafova
            LineSeries linijaS = new LineSeries()
            {
                Title = "Jaja S klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaS, sviDatumiUnosa, rezultatUpitaS);
            //M klasa 
            LineSeries linijaM = new LineSeries()
            {
                Title = "Jaja M klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaM, sviDatumiUnosa, rezultatUpitaM);

            // L klasa
            LineSeries linijaL = new LineSeries()
            {
                Title = "Jaja L klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaL, sviDatumiUnosa, rezultatUpitaL);

            //XL klasa
            LineSeries linijaXL = new LineSeries()
            {
                Title = "Jaja XL klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaXL, sviDatumiUnosa, rezultatUpitaXL);

            foreach (var item in sviDatumiUnosa)
            {
                os.Labels.Add(item.ToShortDateString());
            }
            os.Title = "Datum";
            //brisanje starih podataka iz stupaca kako se ne bi gomilali beskonacno
            outputPrikazStanjaJaja.Series.Clear();
            //brisanje generiranih labela x i y osi
            outputPrikazStanjaJaja.AxisX.Clear();
            outputPrikazStanjaJaja.AxisY.Clear();

            outputPrikazStanjaJaja.LegendLocation = LegendLocation.Bottom;
            //popunjavanje grafa podacima iz serija
            outputPrikazStanjaJaja.Series.Add(linijaS);
            outputPrikazStanjaJaja.Series.Add(linijaM);
            outputPrikazStanjaJaja.Series.Add(linijaL);
            outputPrikazStanjaJaja.Series.Add(linijaXL);

            outputPrikazStanjaJaja.AxisX.Add(os);
            outputPrikazStanjaJaja.AxisY.Add(new Axis
            {
                Title = "Broj jaja",
                //Separator = new Separator()
            });
        }

        private void IscrtajLinijskiGrafProdaje()
        {
            BindingList<ZapisGrafa> rezultatUpitaS;
            BindingList<ZapisGrafa> rezultatUpitaM;
            BindingList<ZapisGrafa> rezultatUpitaL;
            BindingList<ZapisGrafa> rezultatUpitaXL;
            BindingList<DateTime> sviDatumiUnosa;

            rezultatUpitaS = modulZaDohvatPodatakaGrafa.VratiBrojProdanihJajaPoKlasama("S");
            rezultatUpitaM = modulZaDohvatPodatakaGrafa.VratiBrojProdanihJajaPoKlasama("M");
            rezultatUpitaL = modulZaDohvatPodatakaGrafa.VratiBrojProdanihJajaPoKlasama("L");
            rezultatUpitaXL = modulZaDohvatPodatakaGrafa.VratiBrojProdanihJajaPoKlasama("XL");
            sviDatumiUnosa = modulZaDohvatPodatakaGrafa.VratiSveDatumeProdaja();

            //dodavanje osi
            Axis os = new Axis()
            {
                Separator = new Separator()
                {
                    Step = 1,
                    IsEnabled = false
                }

            };
            os.Labels = new List<string>();

            //učitavanje podataka u serije grafova
            LineSeries linijaS = new LineSeries()
            {
                Title = "Jaja S klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaS, sviDatumiUnosa, rezultatUpitaS);
            //M klasa 
            LineSeries linijaM = new LineSeries()
            {
                Title = "Jaja M klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaM, sviDatumiUnosa, rezultatUpitaM);

            // L klasa
            LineSeries linijaL = new LineSeries()
            {
                Title = "Jaja L klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaL, sviDatumiUnosa, rezultatUpitaL);

            //XL klasa
            LineSeries linijaXL = new LineSeries()
            {
                Title = "Jaja XL klase",
                Values = new ChartValues<int>()
            };
            UrediLinijePoDatumima(linijaXL, sviDatumiUnosa, rezultatUpitaXL);

            foreach (var item in sviDatumiUnosa)
            {
                os.Labels.Add(item.ToShortDateString());
            }
            os.Title = "Datum";
            //brisanje starih podataka iz stupaca kako se ne bi gomilali beskonacno
            outputGrafickiPrikazBrojaProdanihJaja.Series.Clear();
            //brisanje generiranih labela x i y osi
            outputGrafickiPrikazBrojaProdanihJaja.AxisX.Clear();
            outputGrafickiPrikazBrojaProdanihJaja.AxisY.Clear();

            outputGrafickiPrikazBrojaProdanihJaja.LegendLocation = LegendLocation.Bottom;
            //popunjavanje grafa podacima iz serija
            outputGrafickiPrikazBrojaProdanihJaja.Series.Add(linijaS);
            outputGrafickiPrikazBrojaProdanihJaja.Series.Add(linijaM);
            outputGrafickiPrikazBrojaProdanihJaja.Series.Add(linijaL);
            outputGrafickiPrikazBrojaProdanihJaja.Series.Add(linijaXL);

            outputGrafickiPrikazBrojaProdanihJaja.AxisX.Add(os);
            outputGrafickiPrikazBrojaProdanihJaja.AxisY.Add(new Axis
            {
                Title = "Broj jaja",
                //Separator = new Separator()
            });
        }

        private void IscrtajStupcastiGrafUginulih()
        {
            BindingList<ZapisGrafa> rezultatUpita;
            KokosiTurnus trenutniTurnus = new KokosiTurnus();
            trenutniTurnus = trenutniTurnus.DohvatiAktivanTurnus();
            rezultatUpita = modulZaDohvatPodatakaGrafa.VratiBrojUginulihPoDatumima(trenutniTurnus.idTurnusa);

            //dodavanje osi
            Axis os = new Axis()
            {
                Separator = new Separator(){Step = 1, IsEnabled = false}
            };
 
            //učitavanje podataka u serije grafova
            ColumnSeries stupciUginulih = new ColumnSeries()
            {
                Title = "Uginule kokoši",
                Values = new ChartValues<int>()
            };

            os.Labels = new List<string>();
            foreach (var item in rezultatUpita)
            {
                stupciUginulih.Values.Add(item.BrojcanaVrijednost);
                os.Labels.Add(item.Dan.ToShortDateString());
                os.Title = "Datum";
            }

            //brisanje starih podataka iz stupaca kako se ne bi gomilali beskonacno
            outputGrafickiPrikazBrojaUginulih.Series.Clear();
            //brisanje generiranih labela x i y osi
            outputGrafickiPrikazBrojaUginulih.AxisX.Clear();
            outputGrafickiPrikazBrojaUginulih.AxisY.Clear();

            outputGrafickiPrikazBrojaUginulih.LegendLocation = LegendLocation.Bottom;
            //popunjavanje grafa podacima iz serija
            outputGrafickiPrikazBrojaUginulih.Series.Add(stupciUginulih);

            outputGrafickiPrikazBrojaUginulih.AxisX.Add(os);
            outputGrafickiPrikazBrojaUginulih.AxisY.Add(new Axis
            {
                Title = "Broj jaja",
                Separator = new Separator()
            });
        }
        #endregion

        #endregion

        #region eventi

        #region pokretanje funkcionalnosti
        private void actionOtvoriEvidencijuJaja_Click(object sender, EventArgs e)
        {
           
            outputKontrolaProzora.SelectedTab = formaEvidencijaJaja;
            VratiBojeSvihElemenataIzbornika();
            PromijeniBojuGumba(actionOtvoriEvidencijuJaja);
            OsvjeziUnesenaJaja();
            IscrtajLinijskiGrafJaja();
        }

        private void actionOtvoriProdajuINarudzbu_Click(object sender, EventArgs e)
        {
            KokosiTurnus odabraniTurnus = new KokosiTurnus();
            odabraniTurnus = odabraniTurnus.DohvatiAktivanTurnus();
            outputKontrolaProzora.SelectedTab = outputKontaktKupca;
            // Select sluzi kako bi se slider nalazio na vrhu prozora.
            outputStanjeSkladista2.Select();
            VratiBojeSvihElemenataIzbornika();
            PromijeniBojuGumba(actionOtvoriProdajuINarudzbu);
            OsvjeziNaruzdbe();
            OsvjeziProdaju();
            IscrtajLinijskiGrafProdaje();
            OsvjeziKupce();
            OsvjeziZapise();
            OsvjeziUkupnoStanjeJaja(odabraniTurnus);
        }

        private void actionOtvoriSirovine_Click(object sender, EventArgs e)
        {
            outputKontrolaProzora.SelectedTab = formaEvidencijaSirovina;
            VratiBojeSvihElemenataIzbornika();
            PromijeniBojuGumba(actionOtvoriSirovine);
            OsvjeziListuSirovina();
            IscrtajGrafSirovina();
        }

        private void actionOtvoriEvidencijuKokosi_Click(object sender, EventArgs e)
        {
            outputKontrolaProzora.SelectedTab = formaEvidencijaKokosi;
            VratiBojeSvihElemenataIzbornika();
            PromijeniBojuGumba(actionOtvoriEvidencijuKokosi);
            OsjveziListuBaterijaKaveza();
            IscrtajStupcastiGrafUginulih();
            OsvjeziListuCijepljenja();
            OsvjeziListuDostupnihCijepljenja();
        }

        private void actionOtvoriUpravljanjeKorisnicima_Click(object sender, EventArgs e)
        {
            outputKontrolaProzora.SelectedTab = formaKorisnik;
            VratiBojeSvihElemenataIzbornika();
            PromijeniBojuGumba(actionOtvoriUpravljanjeKorisnicima);
            OsvjeziListuKorisnika();
        }

        #endregion

        #region pokretanje formi za unos, onclick
        private void actionPokreniFormuZaUnosJaja_Click(object sender, EventArgs e)
        {
            FormaZaUnosJaja formaZaUnosJaja = new FormaZaUnosJaja(prijavljeniKorisnik);
            formaZaUnosJaja.ShowDialog();
            OsvjeziUnesenaJaja();
            IscrtajLinijskiGrafJaja();
            
        }

        private void actionDodajNarudzbu_Click(object sender, EventArgs e)
        {
            FormaZaUnosStavkiNarudzbe formaZaUnosNarudzbe = new FormaZaUnosStavkiNarudzbe(narudzbaBindingSource.Current as Narudzba);
            if (narudzbaBindingSource.Current != null)
            {
                formaZaUnosNarudzbe.ShowDialog();
                OsvjeziStavke(narudzbaBindingSource.Current as Narudzba);
                OsvjeziNaruzdbe();
            }
            else MessageBox.Show("Potrebno je prvo unijeti narudžbu kako biste mogli dodati stavke!");         
        }
        
        private void actionDodajSirovinu_Click(object sender, EventArgs e)
        {
            FormaDodajSirovinu formaDodavanjeSirovine = new FormaDodajSirovinu();
            formaDodavanjeSirovine.ShowDialog();
            OsvjeziListuSirovina();
            IscrtajGrafSirovina();
        }

        private void actionDodajHranu_Click(object sender, EventArgs e)
        {
            FormaDodavanjeHrane formaDodavanjeHrane = new FormaDodavanjeHrane();
            formaDodavanjeHrane.ShowDialog();
            OsvjeziListuSirovina();
            IscrtajGrafSirovina();
        }

        private void actionDodajTurnus_Click(object sender, EventArgs e)
        {
            FormaDodajTurnus formaDodajTurnus = new FormaDodajTurnus();
            formaDodajTurnus.ShowDialog();
            OsjveziListuBaterijaKaveza();
        }

        private void actionDodajCjepivo_Click(object sender, EventArgs e)
        {
            FormaDodavanjeCjepiva formaDodavanjeCjepiva = new FormaDodavanjeCjepiva();
            formaDodavanjeCjepiva.ShowDialog();
            OsvjeziListuDostupnihCijepljenja();
        }

        private void actionObrisiCjepivo_Click(object sender, EventArgs e)
        {
            Cjepivo odabranoCjepivo = outputDostupnaCjepiva.SelectedItem as Cjepivo;
            if(odabranoCjepivo != null)
            {
                using (ChickenCheckEntiteti kontekstZaBrisanjeCjepiva = new ChickenCheckEntiteti())
                {
                    kontekstZaBrisanjeCjepiva.Cjepivo.Attach(odabranoCjepivo);
                    kontekstZaBrisanjeCjepiva.Cjepivo.Remove(odabranoCjepivo);
                    kontekstZaBrisanjeCjepiva.SaveChanges();

                }
            }
            OsvjeziListuDostupnihCijepljenja();
        }

        private void actionEvidentirajCijepljenje_Click(object sender, EventArgs e)
        {
            FormaEvidencijaCijepljenja formaEvidencijaCijepljenja = new FormaEvidencijaCijepljenja();
            formaEvidencijaCijepljenja.ShowDialog();
            OsvjeziListuCijepljenja();
        }

        private void actionObrisiCijepljenje_Click(object sender, EventArgs e)
        {
            Cijepljenje odabranoCijepljenje = outputIzvrsenaCijepljenja.SelectedItem as Cijepljenje;
            if (odabranoCijepljenje != null)
            {
                using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
                {
                    kontekstBazePodataka.Cijepljenje.Attach(odabranoCijepljenje);
                    kontekstBazePodataka.Cijepljenje.Remove(odabranoCijepljenje);
                    kontekstBazePodataka.SaveChanges();
                }
            }
            OsvjeziListuCijepljenja();
            OsvjeziListuDostupnihCijepljenja();
        }
        private void actionDodajKorisnika_Click(object sender, EventArgs e)
        {
            FormaDodavanjeKorisnika formaDodavanjeKorisnika = new FormaDodavanjeKorisnika();
            formaDodavanjeKorisnika.ShowDialog();
            OsvjeziListuKorisnika();
        }

        private void actionUrediKorisnika_Click(object sender, EventArgs e)
        {
            Korisnik odabraniKorisnikZaIzmjenu = korisnikBindingSource.Current as Korisnik;
            FormaDodavanjeKorisnika formaUrediKorisnika = new FormaDodavanjeKorisnika(odabraniKorisnikZaIzmjenu);
            formaUrediKorisnika.ShowDialog();
            OsvjeziListuKorisnika();
        }

        private void ChickenCheck_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            string putanja = Directory.GetCurrentDirectory();
            putanja = putanja.Remove(putanja.Length - 10);
            System.Windows.Forms.Help.ShowHelp(this, "file://"+putanja+"\\help\\ChickenCheckHelp.chm","Korisnička dokumentacija");
        }

        private void actionDodajNarudzbe_Click(object sender, EventArgs e)
        {
            Kupac odabraniKupac = outputPrikazKupaca.SelectedItem as Kupac;
            FormaZaUnosNarudzbi frmNarudzba = new FormaZaUnosNarudzbi(odabraniKupac);
            frmNarudzba.ShowDialog();
            OsvjeziNaruzdbe();
            
        }

        private void actionUnesiBrojUginulihKokosi_Click(object sender, EventArgs e)
        {
            bool parsiranjeBrojaUginulihUspjelo = false;
            int brojUginulih = 0;
            parsiranjeBrojaUginulihUspjelo = int.TryParse(inputUnosUginulihKokosi.Text, out brojUginulih);
            if(inputUnosUginulihKokosi.Text!="" && inputUnosUzroka.Text != "" && brojUginulih>0)
            {
                string uzrok = inputUnosUzroka.Text;
                int brojUginulihKokosi = 0;
                bool uspjeloParsiranjeBrojaUginulih = int.TryParse(inputUnosUginulihKokosi.Text, out brojUginulihKokosi);
                bool evidentirano = false;
                BaterijeKaveza kavezSUginulimKokosima = baterijeKavezaBindingSource.Current as BaterijeKaveza;
                if (kavezSUginulimKokosima != null && uspjeloParsiranjeBrojaUginulih)
                {
                    using (ChickenCheckEntiteti kontekstZaEvidencijuUginulihKokosi = new ChickenCheckEntiteti())
                    {
                        kontekstZaEvidencijuUginulihKokosi.BaterijeKaveza.Attach(kavezSUginulimKokosima);
                        evidentirano = kavezSUginulimKokosima.EvidentiranjeBrojaUginulihKokoški(brojUginulihKokosi);
                        kontekstZaEvidencijuUginulihKokosi.SaveChanges();
                    }
                    if (evidentirano)
                    {
                        MessageBox.Show("Evidentiran je gubitak");
                        OsjveziListuBaterijaKaveza();
                        IscrtajStupcastiGrafUginulih();
                    }
                    else
                    {
                        MessageBox.Show("Evidencija nije izvršena");
                    }

                    UnosUginulih unosUginulih = new UnosUginulih();
                    unosUginulih.UnesiUginule(brojUginulihKokosi, uzrok, kavezSUginulimKokosima, prijavljeniKorisnik);
                }

            }
            else
            {
                MessageBox.Show("Unesite broj uginulih i uzrok smrti");
            }
            
        }

        private void actionObrisiKorisnika_Click(object sender, EventArgs e)
        {
            Korisnik odabraniKorisnikZaBrisanje = korisnikBindingSource.Current as Korisnik;
            if (odabraniKorisnikZaBrisanje != null)
            {
                prijavljeniKorisnik.ObrisiKorisnika(odabraniKorisnikZaBrisanje);
            }
            OsvjeziListuKorisnika();
        }

        private void actionPrebaciProdano_Click(object sender, EventArgs e)
        {
            StanjeNarudzbe novoStanje = new StanjeNarudzbe();
            Narudzba odabranaNarudzba = narudzbaBindingSource.Current as Narudzba;

            if (odabranaNarudzba.ProvjeriDozvoljenuProdaju(odabranaNarudzba))
            {
                if (odabranaNarudzba != null)
                {
                    odabranaNarudzba.PromijeniStanjeNarudzbe(odabranaNarudzba, 2);
                }
                OsvjeziProdaju();
                OsvjeziNaruzdbe();
                stavkeNarudzbeBindingSource.DataSource = null;
                OsvjeziZapise();
            }
            else
            {
                MessageBox.Show("Žao nam je, nemate dovoljno resursa na skladištu!");
            }

        }

        private void actionOtkaziNarudzbu_Click(object sender, EventArgs e)
        {
            StanjeNarudzbe novoStanje = new StanjeNarudzbe();
            Narudzba odabranaNarudzba = narudzbaBindingSource.Current as Narudzba;
            if (odabranaNarudzba != null)
            {
                odabranaNarudzba.PromijeniStanjeNarudzbe(odabranaNarudzba, 3);
            }
            OsvjeziNaruzdbe();
            stavkeNarudzbeBindingSource.DataSource = null;
        }

        private void actionDodajKupca_Click_1(object sender, EventArgs e)
        {
            FormaZaUnosNovogKupca frmUnosNovogKupca = new FormaZaUnosNovogKupca();
            frmUnosNovogKupca.ShowDialog();
            OsvjeziKupce();
        }

        private void actionObrisiKupca_Click(object sender, EventArgs e)
        {
            Kupac odabraniKupac = outputPrikazKupaca.SelectedItem as Kupac;
            using (var kontekstZaBrisanjeKupca = new ChickenCheckEntiteti())
            {
                kontekstZaBrisanjeKupca.Kupac.Attach(odabraniKupac);
                if (odabraniKupac.Narudzba.Count == 0)
                {
                    kontekstZaBrisanjeKupca.Kupac.Remove(odabraniKupac);
                    kontekstZaBrisanjeKupca.SaveChanges();
                }
                else
                {
                    MessageBox.Show("Ne možete obrisati kupca za kojeg postoje određene narudžbe!");
                }
            }
            OsvjeziKupce();
        }

        private void actionObrišiJaja_Click(object sender, EventArgs e)
        {
            Jaja odabranaJaja = jajaBindingSource.Current as Jaja;
            using (var kontekstZaBrisanjeJaja = new ChickenCheckEntiteti())
            {
                kontekstZaBrisanjeJaja.Jaja.Attach(odabranaJaja);
                odabranaJaja.zapisNekativan = true;
                kontekstZaBrisanjeJaja.SaveChanges();
            }
            OsvjeziUnesenaJaja();
            IscrtajLinijskiGrafJaja();
        }

        private void actionIzmijeniKupca_Click(object sender, EventArgs e)
        {
            Kupac odabraniKupac = outputPrikazKupaca.SelectedItem as Kupac;
            if (odabraniKupac != null)
            {
                FormaZaUnosNovogKupca frmIzmjenaKupca = new FormaZaUnosNovogKupca(odabraniKupac);
                frmIzmjenaKupca.ShowDialog();
                OsvjeziKupce();
            }
        }
        /// <summary>
        /// Dodavanje sirovina. Kolicina mora biti pozitivan broj - tome i sluzi ovaj prvi if uvjet
        /// Potrebno je jos dodati provjeru je li kolicina povecana hrani ili sirovini, ako je hrani, potrebno je smanjiti sirovine.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void actionDodajKolicinuSirovina_Click(object sender, EventArgs e)
        {
            izmjeniAzurirajSirovine(inputPromjenaKolicineSirovine.Text, false);

        }

        private void actionOduzmiKolicinuSirovina_Click(object sender, EventArgs e)
        {
            izmjeniAzurirajSirovine(inputPromjenaKolicineSirovine.Text, true);

        }

        private void izmjeniAzurirajSirovine(string izmjenjenaSirovina, bool oduzimanje)
        {
            int promjenjenaKolicina = 0;
            if (int.TryParse(inputPromjenaKolicineSirovine.Text, out promjenjenaKolicina))
            {
                if (oduzimanje)
                {
                    promjenjenaKolicina *= -1;
                }
                Sirovina promjenjenaSirovina = sirovinaBindingSource.Current as Sirovina;

                KontrolerIzmjeneSirovina kontrolerIzmjeneSirovina = new KontrolerIzmjeneSirovina();
                promjenjenaKolicina = kontrolerIzmjeneSirovina.provjeriIspravnostPromjeneSirovine(promjenjenaKolicina, promjenjenaSirovina);

                if (promjenjenaKolicina == 0)
                {
                    MessageBox.Show("Nemate dovoljnu količinu sirovine za navedenu potrošnju!");
                }

                promjenjenaSirovina.izmjeniKolicinuSirovine(promjenjenaKolicina);

                AzuriranjeSirovina azuriranjeSirovina = new AzuriranjeSirovina();
                azuriranjeSirovina.UnesiAzuriraneSirovine(promjenjenaKolicina, promjenjenaSirovina, prijavljeniKorisnik);
                OsvjeziListuSirovina();
                IscrtajGrafSirovina();

            }
            else
            {
                MessageBox.Show("Molim Vas unesite ispravnu vrijednost");
            }
        }

        private void actionIzmijeniStavke_Click(object sender, EventArgs e)
        {
            if (stavkeNarudzbeBindingSource.Current as StavkeNarudzbe != null)
            {
                FormaZaUnosStavkiNarudzbe frmUnosStavki = new FormaZaUnosStavkiNarudzbe(stavkeNarudzbeBindingSource.Current as StavkeNarudzbe);
                frmUnosStavki.ShowDialog();
                if (narudzbaBindingSource.Current as Narudzba != null)
                {
                    OsvjeziStavke(narudzbaBindingSource.Current as Narudzba);
                }
            }else
            {
                MessageBox.Show("Nije moguće jer ne postoji stavka za izmjenu. Koristite opciju za dodavanje stavki");
            }
        }
        #endregion

        #region selection changed

        private void outputKorisnici_SelectionChanged(object sender, EventArgs e)
        {
            Korisnik odabraniKorisnik = korisnikBindingSource.Current as Korisnik;
            if (odabraniKorisnik != null)
            {
                OsvjeziOutputOvlasti(odabraniKorisnik.vratiListuOvlastiKorisnika());
            }

        }

        private void outputTablicaNarudzbi_SelectionChanged(object sender, EventArgs e)
        {
            Narudzba odabrana = narudzbaBindingSource.Current as Narudzba;
            if (odabrana != null)
            {
                OsvjeziStavke(odabrana);
                using (var db = new ChickenCheckEntiteti())
                {

                    db.Narudzba.Attach(odabrana);
                    outputKupac.Text = odabrana.Kupac.naziv;
                }
                OsvjeziKupce();
            }
            else
                outputKupac.Text = "";
        }

        private void ChickenCheck_Load(object sender, EventArgs e)
        {
            OsvjeziUnesenaJaja();
            IscrtajLinijskiGrafJaja();
        }

        private void outputPrikazProdanihJaja_SelectionChanged(object sender, EventArgs e)
        {
            Narudzba odabranaProdaja = narudzbaBindingSource1.Current as Narudzba;
            if (odabranaProdaja != null)
            {

                OsvjeziProdaneStavke(odabranaProdaja);
            }
        }

        private void outputPrikazKupaca_SelectedIndexChanged(object sender, EventArgs e)
        {
            Kupac selektiraniKupac = outputPrikazKupaca.SelectedItem as Kupac;
            if (selektiraniKupac != null)
            {
                outputNazivKupca.Text = "Naziv: " + selektiraniKupac.naziv;
                outputOpisKupca.Text = "Opis: " + selektiraniKupac.opis;
                outputKontaktKupca.Text = "Kontakt: " + selektiraniKupac.kontakt;

            }
        }





        #endregion

        #endregion eventi

    }
}
