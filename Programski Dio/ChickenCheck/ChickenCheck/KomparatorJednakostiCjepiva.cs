using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChickenCheck
{
    class KomparatorJednakostiCjepiva : IEqualityComparer<Cjepivo>
    {
        public bool Equals(Cjepivo x, Cjepivo y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.idCjepiva.Equals(y.idCjepiva);
        }

        public int GetHashCode(Cjepivo obj)
        {
            return obj.idCjepiva.GetHashCode();
        }

    }
}
