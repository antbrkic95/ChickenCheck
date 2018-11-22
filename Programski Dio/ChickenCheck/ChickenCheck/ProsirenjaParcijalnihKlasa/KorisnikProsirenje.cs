using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Korisnik
    {


        #region metode
        /// <summary>
        /// Provjerava postoji li korisnik u bazi podataka za navedeno korisnicko ime i lozinku i vraca ga ukoliko postoji.
        /// </summary>
        /// <param name="unesenoKorisnickoIme">Korisnicko ime za provjeru</param>
        /// <param name="unesenaLozinka">Lozinka za provjeru</param>
        /// <returns></returns>
        public Korisnik ProvjeriKorisnika(string unesenoKorisnickoIme, string unesenaLozinka)
        {
            Korisnik korisnikIzBaze = null;
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                foreach (var korisnik in kontekstBazePodataka.Korisnik)
                {
                    if (korisnik.korisnickoIme == unesenoKorisnickoIme && korisnik.lozinka == unesenaLozinka)
                    {
                        korisnikIzBaze = korisnik;
                    }
                }
            }


            return korisnikIzBaze;

        }
        /// <summary>
        /// Vraca listu svih korisnika iz baze
        /// </summary>
        /// <returns></returns>
        public BindingList<Korisnik> VratiListuKorisnika()
        {
            BindingList<Korisnik> listaKorisnika;
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                var neobrisaniKorisnici = (from korisnik in kontekstBazePodataka.Korisnik where korisnik.zapisNeaktivan == false select korisnik);
                listaKorisnika = new BindingList<Korisnik>(neobrisaniKorisnici.ToList());
            }
            return listaKorisnika;
        }

        /// <summary>
        /// Vraca listu funkcionalnosti korisnika (objekta koji poziva funkciju)
        /// </summary>
        /// <returns></returns>
        public List<Funkcionalnost> vratiListuOvlastiKorisnika()
        {
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                kontekstBazePodataka.Korisnik.Attach(this);
                return this.Funkcionalnost.ToList();
            }
        }

        public void DodajNovogKorisnikaUBazu(Korisnik noviKorisnik)
        {
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                kontekstBazePodataka.Korisnik.Add(noviKorisnik);
                foreach (var item in noviKorisnik.Funkcionalnost)
                {
                    kontekstBazePodataka.Funkcionalnost.Attach(item);
                }
                kontekstBazePodataka.SaveChanges();
            }

        }

        /// <summary>
        /// Ova metoda sluzi za pohranu izmjena o korisniku. Prima staru vrijednost korisnika i novu, promijenjenu vrijednost
        /// </summary>
        /// <param name="stariKorisnik">Objekt klase korisnik, stara vrijednost prije promjene</param>
        /// <param name="noviKorisnik">Objekt klase korisnik kojeg zelimo pohraniti</param>
        public void DodajPostojecegKorisnikaUBazu(Korisnik stariKorisnik, Korisnik noviKorisnik)
        {
            int idKorisnikaZaEdit = stariKorisnik.idKorisnika;
            string sqlString = "delete from OvlastiKorisnika where idKorisnika=@idKorisnikaZaEdit";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand brisanjeOvlastiKorisnika = new SqlCommand(sqlString, connection);
            brisanjeOvlastiKorisnika.Parameters.AddWithValue("@idKorisnikaZaEdit", idKorisnikaZaEdit);
            PristupBaziPodataka.Instance.IzvrsiUpit(brisanjeOvlastiKorisnika);

            foreach (var item in noviKorisnik.Funkcionalnost)
            {
                string insertOvlasti = "insert into OvlastiKorisnika (idKorisnika, idFunkcionalnosti) values (@idKorisnikaZaEdit, @idFunkcionalnosti)";
                SqlCommand insertOvlastiCommand = new SqlCommand(insertOvlasti, connection);
                insertOvlastiCommand.Parameters.AddWithValue("@idKorisnikaZaEdit", idKorisnikaZaEdit);
                insertOvlastiCommand.Parameters.AddWithValue("@idFunkcionalnosti", item.idFunkcionalnosti);

                PristupBaziPodataka.Instance.IzvrsiUpit(insertOvlastiCommand);
            }
            /*string izmjenaPodataka = "update Korisnik set ime = '" + noviKorisnik.ime + "', prezime = '" + noviKorisnik.prezime +
                "', korisnickoIme = '" + noviKorisnik.korisnickoIme + "', lozinka='" + noviKorisnik.lozinka + "', email = '" + noviKorisnik.email + "', telefon = '" + noviKorisnik.telefon + "'" +
                " where idKorisnika = " + idKorisnikaZaEdit;*/
            string izmjenaPodataka = "update Korisnik set ime=@novoIme, prezime=@novoPrezime "+
            ", korisnickoIme=@novoKorisnickoIme, lozinka=@novaLozinka, email=@noviEmail, telefon =@noviTelefon" +
            " where idKorisnika =@idKorisnikaZaEdit";
            SqlCommand izmjenaPodatakaCommand = new SqlCommand(izmjenaPodataka, connection);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@novoIme",noviKorisnik.ime);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@novoPrezime", noviKorisnik.prezime);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@novoKorisnickoIme",noviKorisnik.korisnickoIme);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@novaLozinka", noviKorisnik.lozinka);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@noviEmail", noviKorisnik.email);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@noviTelefon", noviKorisnik.telefon);
            izmjenaPodatakaCommand.Parameters.AddWithValue("@idKorisnikaZaEdit", idKorisnikaZaEdit);

            PristupBaziPodataka.Instance.IzvrsiUpit(izmjenaPodatakaCommand);
        }
        /// <summary>
        /// Ova metoda služi za prividno brisanje korisnika iz sustava. Metoda postavlja njegov atribut obrisan na da
        /// </summary>
        /// <param name="korisnikZaBrisanje"></param>
        public void ObrisiKorisnika(Korisnik korisnikZaBrisanje)
        {
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                kontekstBazePodataka.Korisnik.Attach(korisnikZaBrisanje);
                korisnikZaBrisanje.zapisNeaktivan = true;
                kontekstBazePodataka.SaveChanges();
            }

        }
        #endregion
    }
}
