using Abp.Application.Services;
using Abp.Application.Services.Dto;
using QuickBase.Demo.Application.Contracts.AppServices;
using QuickBase.Demo.Application.Contracts.Dtos;
using QuickBase.Demo.Domain.EqualityComparers;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using QuickBase.Demo.Domain.Services;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Application.AppServices
{
    public class CountryAppService: CrudAppService<Country, CountryDto, int>, ICountryAppService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryManager _countryManager;
        private readonly IStatisticManager _statisticManager;

        public CountryAppService(ICountryRepository countryRepository, ICountryManager countryManager, IStatisticManager statisticManager): base(countryRepository)
        {
            _countryRepository = countryRepository;
            _countryManager = countryManager;
            _statisticManager = statisticManager;
        }

        public async Task<ListResultDto<CountryPopulationDto>> GetAllPopulations()
        {
            var cpSetDb = (await _countryManager.GetCountryPopulationsAsync()).ToHashSet(CountryPopulationEqualityComparer.Instance);
            var cpSetApi = (await _statisticManager.GetCountryPopulationsAsync()).ToHashSet(CountryPopulationEqualityComparer.Instance);

            cpSetDb.UnionWith(cpSetApi);

            var result = new ListResultDto<CountryPopulationDto>(cpSetDb.Select(cp => ObjectMapper.Map(cp, new CountryPopulationDto())).ToList());
            return result;
        }
    }
}
