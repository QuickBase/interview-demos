using Persistence.Interfaces;
using Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Persistence.Concrete
{
    public class CountriesPopulationRepository : DataRepositoryBase
    {
        IQueryable<CityDataModel> _cities;
        IQueryable<CountryDataModel> _contries;
        IQueryable<StateDataModel> _states;

        IQueryable<CityDataModel> Cities => _cities;
        IQueryable<CountryDataModel> Countries => _contries;
        IQueryable<StateDataModel> States => _states;

        public CountriesPopulationRepository(CountriesPopulationDbContext dbContext)
            : base(dbContext)
        {
            _cities = dbContext.Cities.AsQueryable();
            _contries = dbContext.Countries.AsQueryable();
            _states = dbContext.States.AsQueryable();
        }

        protected override IQueryable<T> Get<T>()
        {
            var dbSet = _dbContext.Set<T>();
            return dbSet.AsQueryable<T>();
        }
    }
}
