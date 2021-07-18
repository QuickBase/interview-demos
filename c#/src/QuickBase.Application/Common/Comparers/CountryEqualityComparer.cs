using QuickBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Common.Comparers
{
    public class CountryEqualityComparer : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            if (!AreEqualyNull(x, y) || !AreEqualyNull(x.Name, y.Name))
                return false;

            return x.Name == y.Name;
        }

        private bool AreEqualyNull(object x, object y)
        {
            return (x == null && y == null) || (x != null && y != null);
        }

        public int GetHashCode([DisallowNull] Country obj)
        {
            return obj.Name.GetHashCode();
        }
    }
}
