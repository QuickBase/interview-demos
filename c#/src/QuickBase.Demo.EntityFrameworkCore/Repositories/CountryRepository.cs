using Abp.EntityFrameworkCore;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.Domain.Repositories;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;

namespace QuickBase.Demo.EntityFrameworkCore.Repositories
{
    public class CountryRepository : BaseRepository<Country, int>, ICountryRepository
    {
        public CountryRepository(IDbContextProvider<DemoDbContext> dbContextProvider)
        : base(dbContextProvider)
        {
        }

        public IQueryable<CountryPopulation> GetCountryPopulations()
        {
            var dbContext = GetDbContext();
            return dbContext.Set<CountryPopulation>().AsQueryable();
        }


        public async Task<IQueryable<CountryPopulation>> GetCountryPopulationsAsync()
        {
            var dbContext = await GetDbContextAsync();
            return dbContext.Set<CountryPopulation>().AsQueryable();
        }
    }
}
