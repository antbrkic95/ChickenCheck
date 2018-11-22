using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class AzuriranjeSirovina
    {
        public void UnesiAzuriraneSirovine(int kolicina, Sirovina sirovina, Korisnik prijavljeniKorisnik)
        {
            this.datum = DateTime.Now;
            this.kolicina = kolicina;

            this.Sirovina = sirovina;
            this.Korisnik = prijavljeniKorisnik;

            string formatZapisa = "yyyy-MM-dd";

            /* 
             * Ovo je ranjivo na SQL injection napad - primjer kako prepraviti u paramterizirani upit! 
               string sqlUpit = "INSERT INTO AzuriranjeSirovina(sirovinaId, korisnikId, datum, kolicina)"
                            + "VALUES(" + sirovina.idSirovine + "," + prijavljeniKorisnik.idKorisnika + ",'" + datum.ToString(formatZapisa) + "'," + kolicina + ")";
            */
            string sqlString = "INSERT INTO AzuriranjeSirovina(sirovinaId, korisnikId, datum, kolicina)"
                            + "VALUES(@idSirovine,@idKorisnika,@datum,@kolicina)";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@idSirovine", sirovina.idSirovine);
            sqlUpit.Parameters.AddWithValue("@idKorisnika", prijavljeniKorisnik.idKorisnika);
            sqlUpit.Parameters.AddWithValue("@datum", datum.ToString(formatZapisa));
            sqlUpit.Parameters.AddWithValue("@kolicina", kolicina);

            int rezulatatUpita = PristupBaziPodataka.Instance.IzvrsiUpit(sqlUpit);
        }
    }
}
