using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Cijepljenje
    {
        public void EvidentirajCijepljenje(Cjepivo cjepivo, KokosiTurnus turnus)
        {
            this.Cjepivo = cjepivo;
            this.KokosiTurnus = turnus;
            datumCijepljenja = DateTime.Now;
        }

        public List<Cijepljenje> VratiListuCijepljenja (int proslijedeniTurnusId)
        {
            List<Cijepljenje> listaIzvrsenihCijepljenja;
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                var cijepljenjaTurnusa = (from cijepljenje in kontekstBazePodataka.Cijepljenje where cijepljenje.turnusId == proslijedeniTurnusId select cijepljenje);
                listaIzvrsenihCijepljenja = new List<Cijepljenje>(cijepljenjaTurnusa.ToList());
            }
            return listaIzvrsenihCijepljenja;
        }

        /// <summary>
        /// Ova metoda vraca listu cjepiva na odredenom turnusu (ne cijepljenja vec samo cjepiva)
        /// </summary>
        /// <param name="proslijedeniTurnusId">Turnus koji se provjerava</param>
        /// <returns></returns>
        public BindingList<Cjepivo> VratiListuCjepivaTurnusa(int proslijedeniTurnusId)
        {
            BindingList<Cjepivo> listaIzvrsenihCijepljenja = new BindingList<Cjepivo>();
            BindingList<int> listaIDCjepivaTurnusa;
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                var listaCijepljenjaTurnusa = (from cijepljenje in kontekstBazePodataka.Cijepljenje where cijepljenje.turnusId == proslijedeniTurnusId select cijepljenje.cijepivoId);
                listaIDCjepivaTurnusa = new BindingList<int>(listaCijepljenjaTurnusa.ToList());
                foreach (var item in listaIDCjepivaTurnusa)
                {
                    Cjepivo cjepivoListe = (from cjepivo in kontekstBazePodataka.Cjepivo where cjepivo.idCjepiva == item select cjepivo).FirstOrDefault();
                    listaIzvrsenihCijepljenja.Add(cjepivoListe);
                }
                
            }
            return listaIzvrsenihCijepljenja;
        }

        public override string ToString()
        {
            Cjepivo privremenoCjepivo = new Cjepivo();
            using (ChickenCheckEntiteti kontekstBazePodataka = new ChickenCheckEntiteti())
            {
                var cjepivoCijepljenja = (from cjepivo in kontekstBazePodataka.Cjepivo where cjepivo.idCjepiva == this.cijepivoId select cjepivo).FirstOrDefault();
                privremenoCjepivo = cjepivoCijepljenja;
            }
            return privremenoCjepivo.nazivCjepiva;
        }
    }
}
