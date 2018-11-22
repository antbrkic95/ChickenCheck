using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    partial class Recept
    {
        public void UnesiRecept(Sirovina sastojak, Sirovina hrana, decimal kolicina)
        {
            this.Sirovina = hrana;
            this.Sirovina1 = sastojak;
            this.postotak = kolicina;
        }
    }
}
