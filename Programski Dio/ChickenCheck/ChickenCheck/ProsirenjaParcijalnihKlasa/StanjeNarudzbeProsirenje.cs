using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class StanjeNarudzbe
    {
        public StanjeNarudzbe(string ime)
        {
            nazivStanja = ime;
        }

        /// <summary>
        /// Prikaz svih stanja iz baze
        /// </summary>
        /// <returns></returns>
        public BindingList<StanjeNarudzbe> PrikaziStanja()
        {
            BindingList<StanjeNarudzbe> listaStavki = null;
            using (var db = new ChickenCheckEntiteti())
            {

                listaStavki = new BindingList<StanjeNarudzbe>(db.StanjeNarudzbe.ToList());
            }
            return listaStavki;
        }
        public override string ToString()
        {
            return nazivStanja;
        }
    }
}
