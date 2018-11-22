using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Jaja
    {
        public static List<string> listaKlasa = new List<string>() { "S", "M", "L", "XL" };
        public Jaja(DateTime datum, int kol, string k)
        {
            datumPrikupljanja = datum;
            brojPrikupljenih = kol;
            klasa = k;
        }

        public void DodajJajaUBazu(KokosiTurnus odabraniTurnus)
        {
            using (ChickenCheckEntiteti kontekst = new ChickenCheckEntiteti())
            {
                kontekst.KokosiTurnus.Attach(odabraniTurnus);
                odabraniTurnus.Jaja.Add(this);
                kontekst.SaveChanges();
            }
        }

        public BindingList<Jaja> VratiListuJaja(KokosiTurnus noviTurnus)
        {
            BindingList<Jaja> listaJaja;
            using (ChickenCheckEntiteti kontekst = new ChickenCheckEntiteti())
            {
                kontekst.KokosiTurnus.Attach(noviTurnus);
                int idTurnus = noviTurnus.idTurnusa;

                var neobrisanaJaja = (from jaja in kontekst.Jaja where jaja.zapisNekativan == false && jaja.KokosiTurnus.idTurnusa == idTurnus select jaja);
                listaJaja = new BindingList<Jaja>(neobrisanaJaja.ToList());
                return listaJaja;
            }
        }
        
        /// <summary>
         /// Dohvaæanje ukupnog stanja jaja u bazi za svaku klasu
         /// </summary>
         /// <param name="trenutniTurnus">Aktivni turnus</param>
         /// <returns></returns>
        public int IspisiUkupnoStanje(KokosiTurnus trenutniTurnus, string proslijedenaKlasaJaja)
        {
            int trenutniTurnusId = trenutniTurnus.idTurnusa;
            int suma = 0;
            using (var db = new ChickenCheckEntiteti())
            {
                foreach (var j in db.Jaja)
                {
                    DateTime datumSklanjanja = j.datumPrikupljanja.AddDays(30);
                    if (DateTime.Compare(DateTime.Now.Date, datumSklanjanja.Date) < 0)
                    {
                        if (j.klasa == proslijedenaKlasaJaja && j.KokosiTurnus.idTurnusa == trenutniTurnusId)
                        {
                            suma += j.brojPrikupljenih;
                        }
                    }
                    else if (DateTime.Compare(DateTime.Now.Date, datumSklanjanja.Date) > 0)
                    {
                        if (j.klasa == proslijedenaKlasaJaja)
                        {
                            j.zapisNekativan = true;
                        }
                    }
                }
                db.SaveChanges();
            }
            return suma;
        }
    }
}
