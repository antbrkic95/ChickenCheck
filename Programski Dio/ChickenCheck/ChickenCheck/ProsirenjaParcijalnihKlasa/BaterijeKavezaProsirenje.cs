using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class BaterijeKaveza
    {
        public BaterijeKaveza(int brojKokosi, int brojKaveza)
        {
            this.UnosUginulih = new HashSet<UnosUginulih>();
            this.KokosiTurnus = new HashSet<KokosiTurnus>();
            this.brojKokosi = brojKokosi;
            this.brojKavezaBaterije = brojKaveza;
        }


        public bool EvidentiranjeBrojaUginulihKokoški(int brojUginulih)
        {
            if (brojUginulih >= brojKokosi)
            {
                return false;
            }
            else
            {
                brojKokosi -= brojUginulih;
                return true;
            }
        }
    }
}
