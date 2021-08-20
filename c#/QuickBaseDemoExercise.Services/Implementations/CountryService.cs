using QuickBaseDemoExercise.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Services.Implementations
{
    public class CountryService : ICountryService
    {
        private readonly IEqualityComparer<Country> _contrycomparer;
        private readonly ISourcesService _sourcesService;
        private readonly ICountryIdFactory _countryIdFactory;

        public CountryService(IEqualityComparer<Country> contrycomparer,
            ISourcesService sourcesService,
            ICountryIdFactory countryIdFactory)
        {
            _contrycomparer = contrycomparer;
            _sourcesService = sourcesService;
            _countryIdFactory = countryIdFactory;
        }
        public async Task<List<Country>> GetCountries()
        {
            var sources = _sourcesService.GetCountrySources().OrderBy(x => x.Order);

            var countriesSet = new HashSet<Country>(_contrycomparer);

            foreach (var source in sources)
            {
                var countries = await source.GetCountries();

                foreach (var country in countries)
                {
                    country.Id = _countryIdFactory.BuildId(country);
                }
                countriesSet.UnionWith(countries);
            }

            return countriesSet.ToList();
        }


    }
}
