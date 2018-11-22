using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Narudzba
    {
        public Narudzba(DateTime datum, StanjeNarudzbe stanje, Kupac k, DateTime datumIsporuke)
        {
            this.StavkeNarudzbe = new HashSet<StavkeNarudzbe>();
            datumNarudzbe = datum;
            StanjeNarudzbe = stanje;
            this.Kupac = k;
            this.datumIsporuke = datumIsporuke;
        }

        public void DodajStavkeUListu(StavkeNarudzbe noveStavke)
        {
            StavkeNarudzbe.Add(noveStavke);
        }

        public BindingList<Narudzba> DohvatiNarudzbe()
        {

            BindingList<Narudzba> listaNarudzbi = null;
            using (var db = new ChickenCheckEntiteti())
            {
                var upitNarudzbe = (from n in db.Narudzba where n.StanjeNarudzbe.idStanja == 1 select n);
                listaNarudzbi = new BindingList<Narudzba>(upitNarudzbe.ToList());
                return listaNarudzbi;
            }

        }

        public BindingList<Narudzba> DohvatiProdaju()
        {

            BindingList<Narudzba> listaProdanih = null;
            using (var db = new ChickenCheckEntiteti())
            {
                var upitNarudzbe = (from n in db.Narudzba where n.StanjeNarudzbe.idStanja == 2 select n);
                listaProdanih = new BindingList<Narudzba>(upitNarudzbe.ToList());
                return listaProdanih;
            }
        }

        public void PromijeniStanjeNarudzbe(Narudzba odabrana, int stanje)
        {
            string sqlString = "UPDATE Narudzba SET stanjeNarudzbeId=@stanje WHERE idNarudzbe=@idNarudzbe";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@stanje", stanje);
            sqlUpit.Parameters.AddWithValue("@idNarudzbe", odabrana.idNarudzbe);

            PristupBaziPodataka.Instance.IzvrsiUpit(sqlUpit);
        }

        public BindingList<Narudzba> DohvatiNarudzbeStanje(StanjeNarudzbe stanje)
        {
            BindingList<Narudzba> listaNarudzbi = null;
            using (var db = new ChickenCheckEntiteti())
            {

                db.StanjeNarudzbe.Attach(stanje);
                listaNarudzbi = new BindingList<Narudzba>(stanje.Narudzba.ToList<Narudzba>());
                return listaNarudzbi;
            }


        }
        public void DodajNarudzbuUBazu()
        {
            using (var db = new ChickenCheckEntiteti())
            {
                db.StanjeNarudzbe.Attach(this.StanjeNarudzbe);
                db.Kupac.Attach(this.Kupac);
                db.Narudzba.Add(this);
                db.SaveChanges();
            }
        }
        
         /// <summary>
         /// Metoda koja provjerava moze li se narudzba iz stanja "naruceno" prebaciti u stanje "prodano"
         /// </summary>
         /// <param name="odabranaNarudzba"></param>
         /// <returns></returns>
        public bool ProvjeriDozvoljenuProdaju(Narudzba odabranaNarudzba)
        {
            Jaja prikazJaja = new Jaja();
            KokosiTurnus odabraniTurnus = new KokosiTurnus();
            odabraniTurnus = odabraniTurnus.DohvatiAktivanTurnus();
            int kolicinaS = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "S");
            int kolicinaM = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "M");
            int kolicinaL = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "L");
            int kolicinaXL = prikazJaja.IspisiUkupnoStanje(odabraniTurnus, "XL");
            DohvacanjePodataka noviPodaci = new DohvacanjePodataka();
            int kolicinaProdanihS = noviPodaci.dohvatiProdanaJajaPoKlasi("S");
            int kolicinaProdanihM = noviPodaci.dohvatiProdanaJajaPoKlasi("M");
            int kolicinaProdanihL = noviPodaci.dohvatiProdanaJajaPoKlasi("L");
            int kolicinaProdanihXL = noviPodaci.dohvatiProdanaJajaPoKlasi("XL");
            int rezultatS = 0;
            int rezultatM = 0;
            int rezultatL = 0;
            int rezultatXL = 0;
            if (kolicinaS > kolicinaProdanihS)
            {
                rezultatS = kolicinaS - kolicinaProdanihS;
            }
            if (kolicinaM > kolicinaProdanihM)
            {
                rezultatM = kolicinaM - kolicinaProdanihM;
            }
            if (kolicinaL > kolicinaProdanihL)
            {
                rezultatL = kolicinaL - kolicinaProdanihL;
            }
            if (kolicinaXL > kolicinaProdanihXL)
            {
                rezultatXL = kolicinaXL - kolicinaProdanihXL;
            }
            int sumS = 0;
            int sumM = 0;
            int sumL = 0;
            int sumXL = 0;
            StanjeNarudzbe novoStanje = new StanjeNarudzbe();

            foreach (var k in odabranaNarudzba.StavkeNarudzbe)
            {
                if (k.klasa == "S") sumS += k.kolicina;
                if (k.klasa == "M") sumM += k.kolicina;
                if (k.klasa == "L") sumL += k.kolicina;
                if (k.klasa == "XL") sumXL += k.kolicina;
            }
            if (rezultatS >= sumS && rezultatM >= sumM && rezultatL >= sumL && rezultatXL >= sumXL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
