using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    public class ZapisGrafa
    {
        public DateTime Dan { get; set; }
        public int BrojcanaVrijednost { get; set; } 
        public decimal DecimalnaVrijednost { get; set; }
        public string Naziv { get; set; }

        public ZapisGrafa() { }

        /// <summary>
        /// Konstruktor zapisa grafa za datum i kolicinu
        /// </summary>
        /// <param name="datum"></param>
        /// <param name="prenesenaKolicina"></param>
        public ZapisGrafa(DateTime datum, int prenesenaKolicina)
        {
            this.Dan = datum;
            this.BrojcanaVrijednost = prenesenaKolicina;
        }

        /// <summary>
        /// Konstruktor zapisa grafa za postavljanje naziva i brojcane vrijednosti
        /// </summary>
        /// <param name="prenesenoIme"></param>
        /// <param name="prenesenaKolicina"></param>
        public ZapisGrafa(string prenesenoIme, int prenesenaKolicina)
        {
            this.Naziv = prenesenoIme;
            this.BrojcanaVrijednost = prenesenaKolicina;
        }
        /// <summary>
        /// Konstruktor zapisa grafa za postavljanje naziva i brojcane vrijednosti
        /// </summary>
        /// <param name="prenesenoIme"></param>
        /// <param name="prenesenaKolicina"></param>
        public ZapisGrafa(string prenesenoIme, decimal prenesenaKolicina)
        {
            this.Naziv = prenesenoIme;
            this.DecimalnaVrijednost = prenesenaKolicina;
        }
        /// <summary>
        /// Konstruktor zapisa grafa za sva tri svojstva - kolicina, naziv, datum
        /// </summary>
        /// <param name="preneseniNaziv"></param>
        /// <param name="prenesenaKolicina"></param>
        /// <param name="preneseniDatum"></param>
        public ZapisGrafa(string preneseniNaziv, int prenesenaKolicina, DateTime preneseniDatum)
        {
            this.Dan = preneseniDatum;
            this.BrojcanaVrijednost = prenesenaKolicina;
            this.Naziv = preneseniNaziv;
        }
    }
}