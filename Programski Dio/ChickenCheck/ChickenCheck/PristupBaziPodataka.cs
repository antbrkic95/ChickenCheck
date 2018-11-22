using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Common;
using System.Data.SqlClient;

namespace ChickenCheck
{

    public class PristupBaziPodataka
    {
        private static PristupBaziPodataka instance;
        private SqlConnection connection;
        private string connectionString;

        public static PristupBaziPodataka Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new PristupBaziPodataka();
                }
                return instance;
            }
        }
        public SqlConnection Connection
        {
            get { return connection; }
            private set { connection = value; }
        }
        public string ConnectionString
        {
            get { return connectionString; }
            private set { connectionString = value; }
        }

        private PristupBaziPodataka()
        {
            ConnectionString = "Data Source=31.147.204.119\\PISERVER,1433;Initial Catalog=17022_DB;Persist Security Info=True;User ID=17022_User;Password=2GQEdQrM";
            Connection = new SqlConnection(ConnectionString);
            Connection.Open();
        }

        ~PristupBaziPodataka()
        {
            try
            {
                Connection.Close();
                Connection = null;
            }
            catch (Exception ex)
            {
            }
        }

        /// <summary>
        /// Metoda za dohvacanje datareadera
        /// </summary>
        /// <param name="sqlUpit">upit po kojem se dohvaca</param>
        /// <returns></returns>
        public SqlDataReader DohvatiDataReader(SqlCommand command)
        {
            return command.ExecuteReader();
        }

        /// <summary>
        /// Metoda za dohvat vektora tj jedne vrijednosti iz baze, prema proslijedenom upitu
        /// </summary>
        /// <param name="sqlUpit">upit za dohvat vektora</param>
        /// <returns></returns>
        public object DohvatiVrijednost(SqlCommand command)
        {
            return command.ExecuteScalar();
        }

        /// <summary>
        /// Metoda za izvrsavanje insert / update / delete naredbi i sl.
        /// </summary>
        /// <param name="sqlUpit">Sql naredba koja se proslijeduje</param>
        /// <returns></returns>
        public int IzvrsiUpit(SqlCommand command)
        {
            return command.ExecuteNonQuery();
        }
    }
}