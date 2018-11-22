using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Cjepivo
    {
        public void dodajCjepivo(string nazivCjepiva, string vrstaCjepiva, string opis)
        {
            this.nazivCjepiva = nazivCjepiva;
            this.opis = opis;
            this.vrstaCjepiva = vrstaCjepiva;
        }

        public BindingList<Cjepivo> ispisiCjepiva()
        {
            BindingList<Cjepivo> listaCjepiva = null;
            using (ChickenCheckEntiteti kontekstZaIspisCjepiva = new ChickenCheckEntiteti())
            {
                listaCjepiva = new BindingList<Cjepivo>(kontekstZaIspisCjepiva.Cjepivo.ToList());
                return listaCjepiva;
            }
        }

        public BindingList<Cjepivo> ispisiDostupnaCjepiva()
        {
            IEnumerable<Cjepivo> listaDostupnihCjepiva;
            BindingList<Cjepivo> listaDostupnihCjepiva2;
            Cijepljenje popisCijepljenja = new Cijepljenje();
            Cjepivo privremenoCjepivo = new Cjepivo();
            KokosiTurnus trenutniTurnus = new KokosiTurnus();
            trenutniTurnus = trenutniTurnus.DohvatiAktivanTurnus();


            BindingList<Cjepivo> listaSvihCjepiva = privremenoCjepivo.ispisiCjepiva();
            BindingList<Cjepivo> listaCjepivaTurnusa = popisCijepljenja.VratiListuCjepivaTurnusa(trenutniTurnus.idTurnusa);
            listaDostupnihCjepiva = listaSvihCjepiva.Except(listaCjepivaTurnusa, new KomparatorJednakostiCjepiva()).ToList();
            listaDostupnihCjepiva2 = new BindingList<Cjepivo>(listaDostupnihCjepiva.ToList());
            return listaDostupnihCjepiva2;
        }

        public override string ToString()
        {
            return this.nazivCjepiva;
        }
    }
}
