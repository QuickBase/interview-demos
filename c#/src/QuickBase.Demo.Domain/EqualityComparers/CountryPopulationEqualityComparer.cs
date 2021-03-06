using QuickBase.Demo.Domain.Models;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;

namespace QuickBase.Demo.Domain.EqualityComparers
{
    public class CountryPopulationEqualityComparer : IEqualityComparer<CountryPopulation>
    {
        protected static CountryPopulationEqualityComparer _instance;

        public static CountryPopulationEqualityComparer Instance
        {
            get
            {
                return _instance ??= new CountryPopulationEqualityComparer();
            }
        }

        protected readonly string[][] _countryNames = new[]
        {
            new string[] { "u.s.a.", "united states of america" }
        };

        protected Dictionary<string, SortedSet<string>> _countryNamesComparer;

        protected Dictionary<string, string> _countryNamesAliases;

        protected CountryPopulationEqualityComparer()
        {
            _countryNamesComparer = new Dictionary<string, SortedSet<string>>();
            _countryNamesAliases = new Dictionary<string, string>();
            foreach (var aliases in _countryNames)
            {
                var set = new SortedSet<string>(aliases);
                var key = set.Min;
                _countryNamesComparer.Add(set.Min, set);
                foreach(var alias in aliases)
                    _countryNamesAliases.Add(alias, key);
            }
        }

        public bool Equals([AllowNull] CountryPopulation x, [AllowNull] CountryPopulation y)
        {
            string xKey = x.Name.ToLowerInvariant();
            string yKey = y.Name.ToLowerInvariant();
            if (_countryNamesAliases.ContainsKey(xKey))
                xKey = _countryNamesAliases[xKey];
            if (_countryNamesAliases.ContainsKey(yKey))
                yKey = _countryNamesAliases[yKey];
            return xKey.Equals(yKey);
        }

        public int GetHashCode([DisallowNull] CountryPopulation obj)
        {
            var key = obj.Name.ToLowerInvariant();
            if (_countryNamesAliases.ContainsKey(key))
                return _countryNamesAliases[key].GetHashCode();
            return key.GetHashCode();
        }
    }
}
