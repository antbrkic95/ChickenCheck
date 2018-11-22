using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class UnosUginulih
    {
        public void UnesiUginule(int brojUginulih, string uzrok, BaterijeKaveza baterijaKaveza, Korisnik prijavljeniKorisnik)
        {
            this.datumUnosa = DateTime.Now;
            this.brojUginulihKokosi = brojUginulih;
            this.uzrok = uzrok;

            this.BaterijeKaveza = baterijaKaveza;
            this.Korisnik = prijavljeniKorisnik;

            string formatZapisa = "yyyy-MM-dd";

            /*
             string sqlString = "INSERT INTO UnosUginulih(datumUnosa, baterijaKavezaId, brojUginulihKokosi, korisnikId, uzrok)"
                            + "VALUES('" + datumUnosa.ToString(formatZapisa) + "'," + baterijaKaveza.idBaterije + "," + brojUginulih + "," + prijavljeniKorisnik.idKorisnika + ",'" + uzrok + "')";
             */

            string sqlString = "INSERT INTO UnosUginulih(datumUnosa, baterijaKavezaId, brojUginulihKokosi, korisnikId, uzrok)"
                            + "VALUES(@datumUnosa,@idBaterije,@brojUginulih,@idKorisnika,@uzrok)";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@datumUnosa", datumUnosa.ToString(formatZapisa));
            sqlUpit.Parameters.AddWithValue("@idBaterije", baterijaKaveza.idBaterije);
            sqlUpit.Parameters.AddWithValue("@brojUginulih", brojUginulih);
            sqlUpit.Parameters.AddWithValue("@idKorisnika", prijavljeniKorisnik.idKorisnika);
            sqlUpit.Parameters.AddWithValue("@uzrok", uzrok);

            int rezulatatUpita = PristupBaziPodataka.Instance.IzvrsiUpit(sqlUpit);
        }
    }
}
