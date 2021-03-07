using Abp.Application.Services;
using Abp.Application.Services.Dto;
using QuickBase.Demo.Application.Contracts.AppServices;
using QuickBase.Demo.Application.Contracts.Dtos;
using QuickBase.Demo.Domain.EqualityComparers;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using QuickBase.Demo.Domain.Services;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.Demo.Application.AppServices
{
    public class CountryAppService: CrudAppService<Country, CountryDto, int>, ICountryAppService
    {
        private readonly ICountryRepository _countryRepository;
        private readonly ICountryManager _countryManager;
        private readonly IStatisticManager _statisticManager;
        private readonly IEqualityComparer<CountryPopulation> _cpComparer;

        public CountryAppService(ICountryRepository countryRepository, ICountryManager countryManager, IStatisticManager statisticManager, IEqualityComparer<CountryPopulation> cpComparer) : base(countryRepository)
        {
            _countryRepository = countryRepository;
            _countryManager = countryManager;
            _statisticManager = statisticManager;
            _cpComparer = cpComparer;
        }

        public async Task<ListResultDto<CountryPopulationDto>> GetAllPopulations()
        {
            var cpSetDb = (await _countryManager.GetCountryPopulationsAsync()).ToHashSet(_cpComparer);
            var cpSetApi = (await _statisticManager.GetCountryPopulationsAsync()).ToHashSet(_cpComparer);

            cpSetDb.UnionWith(cpSetApi);

            var result = new ListResultDto<CountryPopulationDto>(cpSetDb.Select(cp => ObjectMapper.Map(cp, new CountryPopulationDto())).ToList());
            return result;
        }
    }
}
