using QuickBase.Application.Common.DataNormalizer;
using QuickBase.Domain.Entities;
using QuickBase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Common.Repositories
{
    public class CountrySourcesRepository : ICountryRepository
    {
        private readonly ICountryApiRepository apiRepository;
        private readonly ICountryDatabaseRepository databaseRepository;
        private readonly IEqualityComparer<Country> countryComparer;
        private readonly ICountryNameNormalizer countryNameNormalizer;

        public CountrySourcesRepository(ICountryApiRepository apiRepository,
            ICountryDatabaseRepository databaseCountryRepository,
            IEqualityComparer<Country> countryComparer,
            ICountryNameNormalizer countryNameNormalizer)
        {
            this.apiRepository = apiRepository;
            this.databaseRepository = databaseCountryRepository;
            this.countryComparer = countryComparer;
            this.countryNameNormalizer = countryNameNormalizer;
        }

        public async Task<List<Country>> GetCountries()
        {
            var countriesSet = new HashSet<Country>(countryComparer);

            foreach (var repo in GetCountrySources())
            {
                var countries = await repo.GetCountries();
                countries.ForEach(NormalizeName);
                countriesSet.UnionWith(countries);
            }

            return countriesSet.ToList();
        }

        private IEnumerable<ICountryRepository> GetCountrySources()
        {
            yield return databaseRepository;
            yield return apiRepository;
        }

        private void NormalizeName(Country country)
        {
            country.Name = countryNameNormalizer.NormalizeName(country.Name);
        }
    }
}
