using QuickBaseDemoExercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Services.Implementations
{
    class CountryService : ICountryService
    {
        private readonly IEqualityComparer<Country> _contrycomparer;

        public CountryService(IEqualityComparer<Country> contrycomparer)
        {
            _contrycomparer = contrycomparer;
        }
        public async Task<List<Country>> GetCountries()
        {
            var sources = GetCountrySources().OrderBy(x => x.Order);

            var countriesSet = new HashSet<Country>(_contrycomparer);

            foreach (var source in sources)
            {
                countriesSet.UnionWith(await source.GetCountries());
            }

            return countriesSet.ToList();
        }

        private IEnumerable<ICountrySourceService> GetCountrySources()
        {
            return new List<ICountrySourceService>()
            {
                new CountryApiService(),
                new CountryDbService()
            };
        }
    }
}
