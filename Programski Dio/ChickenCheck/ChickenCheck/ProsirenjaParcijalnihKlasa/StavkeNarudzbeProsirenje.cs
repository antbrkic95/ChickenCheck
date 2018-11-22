using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class StavkeNarudzbe
    {
        public static List<string> listaKlasa = new List<string>() { "S", "M", "L", "XL" };
        public StavkeNarudzbe() { }
        public StavkeNarudzbe(int kol, string k, double c)
        {

            kolicina = kol;
            klasa = k;
            cijena = c;
        }

        /// <summary>
        /// Prikaz stavke za odabranu narudzbu
        /// </summary>
        /// <param name="nova"></param>
        /// <returns></returns>
        public BindingList<StavkeNarudzbe> PrikaziStavke(Narudzba nova)
        {
            BindingList<StavkeNarudzbe> listaStavki = null;
            using (var db = new ChickenCheckEntiteti())
            {
                if (nova != null)
                {
                    db.Narudzba.Attach(nova);
                    listaStavki = new BindingList<StavkeNarudzbe>(nova.StavkeNarudzbe.ToList<StavkeNarudzbe>());
                }


            }
            return listaStavki;

        }

        public void DodajStavkeUBazu(Narudzba nova)
        {
            using (var db = new ChickenCheckEntiteti())
            {
                db.Narudzba.Attach(nova);
                nova.StavkeNarudzbe.Add(this);
                db.SaveChanges();
            }
        }
    }
}
