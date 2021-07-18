using Microsoft.EntityFrameworkCore;
using QuickBase.Domain.Entities;
using QuickBase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Persistence.Repositories
{
    public class CountryRepository : ICountryDatabaseRepository
    {
        private readonly QuickBaseDbContext db;

        public CountryRepository(QuickBaseDbContext db)
        {
            this.db = db;
        }

        public async Task<List<Country>> GetCountries()
        {
            var countries = from country in db.Countries
                            join state in db.States on country.CountryId.GetValueOrDefault() equals state.CountryId
                            join city in db.Cities on state.StateId equals city.StateId
                            group new { country, city } by country.CountryName into countryGroup
                            select new Country()
                            {
                                Name = countryGroup.Key,
                                Population = countryGroup.Sum(x => x.city.Population.GetValueOrDefault())
                            };

            return await countries.ToListAsync();
        }
    }
}
