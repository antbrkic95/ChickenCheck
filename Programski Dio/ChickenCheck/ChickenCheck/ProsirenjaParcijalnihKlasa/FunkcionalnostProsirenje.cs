using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Funkcionalnost
    {
        #region metode
        public override string ToString()
        {
            return this.nazivFunkcionalnosti;
        }
        /// <summary>
        /// Vraca bindinglist svih funkcionalnosti
        /// </summary>
        /// <returns></returns>
        public static BindingList<Funkcionalnost> VratiListuSvihFunkcionalnosti()
        {
            BindingList<Funkcionalnost> listaFunkcionalnosti;
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                listaFunkcionalnosti = new BindingList<Funkcionalnost>(kontekstBazePodataka.Funkcionalnost.ToList());
            }
            return listaFunkcionalnosti;
        }
        #endregion
    }
}
