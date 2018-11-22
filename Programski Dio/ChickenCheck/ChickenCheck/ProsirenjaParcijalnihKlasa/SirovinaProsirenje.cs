using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data.Entity;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Sirovina
    {
        public static BindingList<Sirovina> recept = new BindingList<Sirovina>();
        public void dodajSirovinu(string nazivSirovine, string opisSirovine, int kolicina)
        {
            this.nazivSirovine = nazivSirovine;
            this.opis = opisSirovine;
            this.kolicina = kolicina;
        }

        public void dodajHranu(string nazivSirovine, string opisSirovine)
        {
            this.nazivSirovine = nazivSirovine;
            this.opis = opisSirovine;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="sirovina"></param>
        /// <param name="kolicina"></param>
        public void dodajSirovinuZaHranu(Sirovina sirovina, int kolicina)
        {
            bool vecPostoji = false;
            decimal ukupnaKolicina = 0;
            foreach (Sirovina pojedinaSirovinaRecepta in Sirovina.recept)
            {
                ukupnaKolicina += pojedinaSirovinaRecepta.kolicina;
            }

            ukupnaKolicina += kolicina;

            Sirovina novaSirovina = new Sirovina();
            novaSirovina = sirovina;
            novaSirovina.kolicina = kolicina;

            if (Sirovina.recept.Count == 0)
            {
                Sirovina.recept.Add(novaSirovina);

            }
            else
            {
                foreach (Sirovina pojedinaSirovinaRecepta in Sirovina.recept)
                {
                    if (pojedinaSirovinaRecepta.nazivSirovine == sirovina.nazivSirovine)
                    {
                        pojedinaSirovinaRecepta.kolicina += kolicina;
                        vecPostoji = true;
                    }
                }
                if (vecPostoji == false)
                {
                    Sirovina.recept.Add(novaSirovina);
                }
            }


            this.kolicina = ukupnaKolicina;

        }

        public BindingList<Sirovina> ispisiSirovine()
        {
            BindingList<Sirovina> listaSirovina = null;
            using (ChickenCheckEntiteti kontekstZaIspisSirovina = new ChickenCheckEntiteti())
            {
                listaSirovina = new BindingList<Sirovina>(kontekstZaIspisSirovina.Sirovina.ToList());
                return listaSirovina;
            }

        }

        public void izmjeniKolicinuSirovine(int kolicina)
        {
            SqlConnection connection = PristupBaziPodataka.Instance.Connection;
  
            this.kolicina += kolicina;

            string izmjenaKolicine = "UPDATE Sirovina set kolicina = @kolicina WHERE idSirovine = @ID";
            SqlCommand izmjenaKolicineCommand = new SqlCommand(izmjenaKolicine, connection);
            izmjenaKolicineCommand.Parameters.AddWithValue("@kolicina", this.kolicina);
            izmjenaKolicineCommand.Parameters.AddWithValue("@ID", this.idSirovine);
            PristupBaziPodataka.Instance.IzvrsiUpit(izmjenaKolicineCommand);
        }
        public void oduzmiHranu(decimal kolicina)
        {
            this.kolicina -= kolicina;
        }


        public override string ToString()
        {
            return this.idSirovine + " " + this.nazivSirovine + " " + this.kolicina;
        }
    }
}
