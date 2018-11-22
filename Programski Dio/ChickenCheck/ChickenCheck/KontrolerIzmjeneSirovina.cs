using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    class KontrolerIzmjeneSirovina
    {
        private int PromjenjenaKolicina { get; set; }
        private Sirovina PromjenjenaSirovina { get; set; }


        public KontrolerIzmjeneSirovina()
        {
           
        }

        public int provjeriIspravnostPromjeneSirovine(int promjenjenaKolicina, Sirovina promjenjenaSirovina)
        {
            this.PromjenjenaSirovina = promjenjenaSirovina;
            this.PromjenjenaKolicina = promjenjenaKolicina;

            if (PromjenjenaSirovina != null)
            {
                if (this.PromjenjenaKolicina < 0)
                {
                    if (this.provjeriRaspolozivostPriOduzimanjuSirovina() == false)
                    {
                        this.PromjenjenaKolicina = 0;
                    }
                }
                return this.PromjenjenaKolicina;
            }
            return 0;
        }

        public bool provjeriRaspolozivostPriOduzimanjuSirovina()
        {
            if (this.PromjenjenaSirovina.kolicina + this.PromjenjenaKolicina > 0)
            {
                return true;
            }
            return false;
        }

    }
}
