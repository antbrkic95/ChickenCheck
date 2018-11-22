using System.Collections.Generic;

namespace ChickenCheck
{
    class KomparatorJednakostiFunkcionalnosti : IEqualityComparer<Funkcionalnost>
    { 
        public bool Equals(Funkcionalnost x, Funkcionalnost y)
        {
            if (object.ReferenceEquals(x, y))
                return true;
            if (x == null || y == null)
                return false;
            return x.idFunkcionalnosti.Equals(y.idFunkcionalnosti);
        }

        public int GetHashCode(Funkcionalnost obj)
        {
            return obj.idFunkcionalnosti.GetHashCode();
        }
        
    }
}
