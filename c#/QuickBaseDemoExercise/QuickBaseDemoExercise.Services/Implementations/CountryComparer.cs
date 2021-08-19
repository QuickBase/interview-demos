using QuickBaseDemoExercise.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace QuickBaseDemoExercise.Services.Implementations
{
    public class CountryComparer : IEqualityComparer<Country>
    {
        public bool Equals(Country x, Country y)
        {
            return x.Id.Equals(y.Id);
        }

        public int GetHashCode(Country obj)
        {
            return obj.Id.GetHashCode();
        }
    }
}
