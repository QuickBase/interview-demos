using QuickBaseDemoExercise.DataBase.Repositories;
using QuickBaseDemoExercise.Domain;
using QuickBaseDemoExercise.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using System.Linq;


namespace QuickBaseDemoExercise.DataBase
{
    public class CountryDbService : ICountrySourceService
    {
        private readonly ICountryRepository countryRepository;

        public CountryDbService(ICountryRepository countryRepository)
        {
            this.countryRepository = countryRepository;
        }
        public int Order { get => 1; }

        public async Task<List<Country>> GetCountries()
        {
            var query = countryRepository.Get()
                .AsNoTracking()
                .Include(x => x.States)
                .ThenInclude(x => x.Cities);

            return await query.Select(x => new Country()
            {
                Name = x.CountryName,
                Population = x.States.Sum(state => state.Cities.Sum(city => city.Population.GetValueOrDefault()))
            }).ToListAsync();
        }
    }
}
