using Application.Models;
using Application.Services.Interfaces;
using Persistence.Concrete.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Application.Services
{
    public class CountriesPopulationService : ICountriesPopulationService
    {
        private readonly IStaticCountriesDataProvider _staticDataProvider;
        private readonly ICountriesPopulationRepository _dataRepository;

        public CountriesPopulationService(IStaticCountriesDataProvider staticDataProvider,
            ICountriesPopulationRepository dataRepository)
        {
            _staticDataProvider = staticDataProvider;
            _dataRepository = dataRepository;
        }

        public IEnumerable<CountriesPopulationResponseModel> GetCountriesPopulation()
        {
            List<CountriesPopulationResponseModel> results = new List<CountriesPopulationResponseModel>();
            var staticCountriesData = _staticDataProvider.GetCountryPopulations();
            var dbCountriesData = _dataRepository.Countries;

            var duplicates = staticCountriesData
                .Select(el => el.Item1)
                .Intersect(dbCountriesData.Select(el => el.CountryName));

            AddNonDuplicatesStaticData(results, staticCountriesData, duplicates);
            AddDbData(results, dbCountriesData);

            return results;
        }

        private void AddDbData(List<CountriesPopulationResponseModel> results, IQueryable<Persistence.Models.CountryDataModel> dbCountriesData)
        {
            var countriesToFetch = dbCountriesData
                            .Where(c => !results.Select(el => el.CountryName).Contains(c.CountryName));

            foreach (var country in countriesToFetch)
            {
                int countryPopulation = GetCountryPopulationFromDb(country.CountryId);

                var responseModel = new CountriesPopulationResponseModel()
                {
                    CountryName = country.CountryName,
                    CountryPopulation = countryPopulation
                };

                if (responseModel != null)
                {
                    results.Add(responseModel);
                }
            }
        }

        private static void AddNonDuplicatesStaticData(List<CountriesPopulationResponseModel> results, List<Tuple<string, int>> staticCountriesData, IEnumerable<string> duplicates)
        {
            foreach (var item in staticCountriesData)
            {
                if (!duplicates.Contains(item.Item1))
                {
                    var responseModel = new CountriesPopulationResponseModel()
                    {
                        CountryName = item.Item1,
                        CountryPopulation = item.Item2
                    };

                    results.Add(responseModel);
                }
            }
        }

        private int GetCountryPopulationFromDb(int countryId)
        {
            int countryPopulation = 0;

            var stateIds = _dataRepository.States
                .Where(s => s.CountryId.Equals(countryId))
                .Select(s => s.StateId);


            foreach (var stateId in stateIds)
            {
                var cityPopulations = _dataRepository.Cities
                    .Where(c => c.StateId.Equals(stateId))
                    .Select(c => c.Population);

                countryPopulation += cityPopulations.Sum();

            }

            return countryPopulation;
        }
    }
}
