using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class UnositeljJaja
    {
        /// <summary>
        /// Ažuriranje zapisa o unesenim jajima
        /// </summary>
        /// <param name="jaja"></param>
        /// <param name="prijavljeniKorisnik"></param>
        public void UnesiAzuriranjeJaja(Jaja jaja, Korisnik prijavljeniKorisnik)
        {
            this.datum = DateTime.Now;
            this.Jaja = jaja;
            this.Korisnik = prijavljeniKorisnik;

            string formatZapisa = "yyyy-MM-dd";

            /*
             string sqlString = "INSERT INTO UnositeljJaja(dnevnaSerijaId, korisnikId, datum)"
                            + "VALUES(" + jaja.idDnevneSerije + ", " + prijavljeniKorisnik.idKorisnika + ", '" + datum.ToString(formatZapisa) + "')";
             */
            string sqlString = "INSERT INTO UnositeljJaja(dnevnaSerijaId, korisnikId, datum)"
                            + "VALUES(@idDnevneSerije,@idKorisnika,@datum)";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@idDnevneSerije", jaja.idDnevneSerije);
            sqlUpit.Parameters.AddWithValue("@idKorisnika", prijavljeniKorisnik.idKorisnika);
            sqlUpit.Parameters.AddWithValue("@datum", datum.ToString(formatZapisa));

            int rezulatatUpita = PristupBaziPodataka.Instance.IzvrsiUpit(sqlUpit);
        }
    }
}
