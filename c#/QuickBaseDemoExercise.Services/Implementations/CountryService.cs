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
        private readonly IServiceProvider _serviceProvider;
        private readonly ICountryIdFactory _countryIdFactory;

        public CountryService(IEqualityComparer<Country> contrycomparer,
            IServiceProvider serviceProvider, ICountryIdFactory countryIdFactory)
        {
            _contrycomparer = contrycomparer;
            _serviceProvider = serviceProvider;
            _countryIdFactory = countryIdFactory;
        }
        public async Task<List<Country>> GetCountries()
        {
            var sources = GetCountrySources().OrderBy(x => x.Order);

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

        private IEnumerable<ICountrySourceService> GetCountrySources()
        {
            return AppDomain.CurrentDomain.GetAssemblies().SelectMany(x => x.GetTypes())
                .Where(x => x.IsClass && x.GetInterfaces().Contains(typeof(ICountrySourceService)))
                .Select(x =>
                {
                    return _serviceProvider.GetService(x) as ICountrySourceService;
                })
                .ToList();
        }
    }
}
