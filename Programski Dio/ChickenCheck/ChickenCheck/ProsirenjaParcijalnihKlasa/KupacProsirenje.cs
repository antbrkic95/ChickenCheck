using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Kupac
    {

        public Kupac(string ime, string opis, string kontakt)
        {
            naziv = ime;
            this.opis = opis;
            this.kontakt = kontakt;
        }

        public BindingList<Kupac> DohvatiKupce()
        {

            BindingList<Kupac> listaKupaca = null;
            using (var db = new ChickenCheckEntiteti())
            {

                listaKupaca = new BindingList<Kupac>(db.Kupac.ToList());
                return listaKupaca;
            }

        }
        public override string ToString()
        {
            return naziv;
        }
    }
}
