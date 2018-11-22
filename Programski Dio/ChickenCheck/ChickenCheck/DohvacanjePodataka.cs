using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    public class DohvacanjePodataka
    {
        #region metode za linijski graf stanja jaja

        /// <summary>
        /// Metoda koja vraca bindingListu svih datuma unosa jaja za određeni  turnus
        /// </summary>
        /// <param name="turnusId">Turnus za koji se dohvaca lista datuma</param>
        /// <returns></returns>
        public BindingList<DateTime> VratiDatumeUnosaJaja(int turnusId)
        {
            BindingList<DateTime> privremenaLista = new BindingList<DateTime>();
            
            string sqlString = "select datumPrikupljanja as datum from dbo.Jaja where turnusId=@turnusId group by datumPrikupljanja order by datumPrikupljanja asc";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@turnusId", turnusId);

            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                DateTime datum = DateTime.Parse(dataReader["datum"].ToString());
                privremenaLista.Add(datum);
            }
            dataReader.Close();
            return privremenaLista;
        }

        /// <summary>
        /// Metoda koja vraca listu broja jaja grupiranih po klasama za odredeni turnus
        /// </summary>
        /// <param name="klasa"></param>
        /// <param name="turnusId"></param>
        /// <returns></returns>
        public BindingList<ZapisGrafa> VratiBrojJajaPoKlasama(string klasa, int turnusId)
        {
            BindingList<ZapisGrafa> privremenaLista = new BindingList<ZapisGrafa>();
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            string sqlString = "select datumPrikupljanja as dan, sum(dbo.Jaja.brojPrikupljenih) as broj from dbo.Jaja" +
                                " where datumPrikupljanja is not null and dbo.Jaja.klasa=@klasa and turnusId=@turnusId"+
                                " group by datumPrikupljanja " +
                                " order by datumPrikupljanja asc";

            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@klasa", klasa);
            sqlUpit.Parameters.AddWithValue("@turnusId", turnusId);

            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                DateTime dan = DateTime.Parse(dataReader["dan"].ToString());
                int kolicina = int.Parse(dataReader["broj"].ToString());
                ZapisGrafa pojedinacniZapis = new ZapisGrafa(dan, kolicina);
                privremenaLista.Add(pojedinacniZapis);

            }
            dataReader.Close();
            return privremenaLista;
        }
        #endregion

        #region Piechart stanje sirovina 
        /// <summary>
        /// Metoda koja vraca listu sa trenutnim stanjima sirovina u bazi.
        /// </summary>
        /// <returns></returns>
        public BindingList<ZapisGrafa> VratiStanjaSirovina()
        {
            BindingList<ZapisGrafa> privremenaLista = new BindingList<ZapisGrafa>();

            string sqlString = "select sum(Sirovina.kolicina) as kolicina, nazivSirovine as naziv from Sirovina group by nazivSirovine";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);

            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                string nazivSirovine = dataReader["naziv"].ToString();
                decimal kolicina = decimal.Parse(dataReader["kolicina"].ToString());
                ZapisGrafa pojedinacniZapis = new ZapisGrafa(nazivSirovine, kolicina);
                privremenaLista.Add(pojedinacniZapis);
            }
            dataReader.Close();
            return privremenaLista;
        }
        #endregion

        #region metode za linijski graf prodaje
        /// <summary>
        /// Metoda koja vraca listu svih datuma prodaje 
        /// </summary>
        /// <returns></returns>
        public BindingList<DateTime> VratiSveDatumeProdaja()
        {
            BindingList<DateTime> privremenaLista = new BindingList<DateTime>();
            string sqlString = "select datumNarudzbe as datum"+
                             " from Narudzba join StavkeNarudzbe on Narudzba.idNarudzbe = StavkeNarudzbe.narudzbaId"+
                             " where Narudzba.stanjeNarudzbeId = 2"+
                             " group by Narudzba.datumNarudzbe"+
                             " order by Narudzba.datumNarudzbe asc";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);

            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                DateTime datum = DateTime.Parse(dataReader["datum"].ToString());
                privremenaLista.Add(datum);
            }
            dataReader.Close();
            return privremenaLista;
        }

        /// <summary>
        /// metoda koja vraca kolicinu prodanih jaja za odredenu klasu
        /// </summary>
        /// <param name="klasa">Klasa prodanih jaja koja se pretrazuje</param>
        /// <returns></returns>
        public BindingList<ZapisGrafa> VratiBrojProdanihJajaPoKlasama(string klasa)
        {
            BindingList<ZapisGrafa> privremenaLista = new BindingList<ZapisGrafa>();

            string sqlString = "select sum(StavkeNarudzbe.kolicina) as kolicina, datumNarudzbe as datum" +
                                " from Narudzba join StavkeNarudzbe on Narudzba.idNarudzbe = StavkeNarudzbe.narudzbaId" +
                                " where StavkeNarudzbe.klasa=@klasa and Narudzba.stanjeNarudzbeId = 2" +
                                " group by Narudzba.datumNarudzbe" +
                                " order by Narudzba.datumNarudzbe asc";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@klasa", klasa);
            
            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                DateTime dan = DateTime.Parse(dataReader["datum"].ToString());
                int kolicina = int.Parse(dataReader["kolicina"].ToString());
                ZapisGrafa pojedinacniZapis = new ZapisGrafa(dan, kolicina);
                privremenaLista.Add(pojedinacniZapis);
            }
            dataReader.Close();
            return privremenaLista;
        }
        #endregion

        #region metode za stupcasti graf uginulih
        /// <summary>
        /// Metoda koja vraca listu s podacima o datumu i broju uginulih kokosi na taj datum za odredeni turnus
        /// </summary>
        /// <param name="idTurnusa">turnus za koji se provjerava</param>
        /// <returns></returns>
        public BindingList<ZapisGrafa> VratiBrojUginulihPoDatumima(int idTurnusa)
        {
            BindingList<ZapisGrafa> privremenaLista = new BindingList<ZapisGrafa>();

            string sqlString = "select datumUnosa as datum, sum(brojUginulihKokosi) as broj"+
                            " from UnosUginulih join BaterijeKaveza on UnosUginulih.baterijaKavezaId = BaterijeKaveza.idBaterije join BaterijeTurnusa on BaterijeKaveza.idBaterije = BaterijeTurnusa.idBaterije"+
                            " where BaterijeTurnusa.idTurnusa =@idTurnusa" +
                            " group by datumUnosa";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@idTurnusa", idTurnusa);

            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                DateTime dan = DateTime.Parse(dataReader["datum"].ToString());
                int kolicina = int.Parse(dataReader["broj"].ToString());
                ZapisGrafa pojedinacniZapis = new ZapisGrafa(dan, kolicina);
                privremenaLista.Add(pojedinacniZapis);
            }
            dataReader.Close();
            return privremenaLista;
        }
        #endregion

        /// <summary>
        /// Metoda koja dohvaca broj prodanih jaja grupiranih po klasi u zadnjih mjesec dana
        /// </summary>
        /// <param name="klasa">klasa prema kojoj se grupira</param>
        /// <returns></returns>
        public int dohvatiProdanaJajaPoKlasi(string klasa)
        {
            int kolicinaJaja = 0;
            var prethodniMjesec = DateTime.Today.AddMonths(-1);
            string formatZapisa = "yyyy-MM-dd";
            //string datumPrijeMjesec = prethodniMjesec.ToShortDateString();
            
            string sqlString = "select sum(StavkeNarudzbe.kolicina) as kolicina, klasa as klasa" +
                                 " from Narudzba join StavkeNarudzbe on Narudzba.idNarudzbe = StavkeNarudzbe.narudzbaId" +
                                " where Narudzba.stanjeNarudzbeId = 2 and datumNarudzbe >= @prethodniMjesec and klasa=@klasa" +
                                " group by klasa";
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
            SqlCommand sqlUpit = new SqlCommand(sqlString, connection);
            sqlUpit.Parameters.AddWithValue("@prethodniMjesec", prethodniMjesec.ToString(formatZapisa));
            sqlUpit.Parameters.AddWithValue("@klasa", klasa);

            SqlDataReader dataReader = PristupBaziPodataka.Instance.DohvatiDataReader(sqlUpit);
            while (dataReader.Read())
            {
                 kolicinaJaja = int.Parse(dataReader["kolicina"].ToString());
            }
            dataReader.Close();
            return kolicinaJaja;

        }
        
    }
}
