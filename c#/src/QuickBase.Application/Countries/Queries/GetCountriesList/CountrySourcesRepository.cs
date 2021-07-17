using QuickBase.Domain.Entities;
using QuickBase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Application.Countries.Queries.GetCountriesList
{
    public class CountrySourcesRepository : ICountryRepository
    {
        private readonly IApiCountryRepository apiRepository;
        private readonly IDatabaseCountryRepository databaseRepository;
        private readonly IEqualityComparer<Country> countryComparer;

        public CountrySourcesRepository(IApiCountryRepository apiRepository,
            IDatabaseCountryRepository databaseCountryRepository,
            IEqualityComparer<Country> countryComparer)
        {
            this.apiRepository = apiRepository;
            this.databaseRepository = databaseCountryRepository;
            this.countryComparer = countryComparer;
        }

        public async Task<List<Country>> GetCountries()
        {
            var dbContries = (await databaseRepository.GetCountries()).ToHashSet(countryComparer);
            dbContries.UnionWith(await apiRepository.GetCountries());
            return dbContries.ToList();
        }
    }
}
