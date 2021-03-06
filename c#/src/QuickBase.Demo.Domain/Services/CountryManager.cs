using Abp.Domain.Services;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Domain.Services
{
    public class CountryManager: DomainService, ICountryManager
    {
        private readonly ICountryRepository _countryRepository;

        public CountryManager(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        public IQueryable<CountryPopulation> GetCountryPopulations()
        {
            return _countryRepository.GetCountryPopulations();
        }

        public async Task<IQueryable<CountryPopulation>> GetCountryPopulationsAsync()
        {
            return await _countryRepository.GetCountryPopulationsAsync();
        }
    }
}
