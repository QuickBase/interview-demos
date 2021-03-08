using Persistence.Concrete.Interfaces;
using Persistence.Models;
using System.Linq;

namespace Persistence.Concrete
{
    public class CountriesPopulationRepository : DataRepositoryBase, ICountriesPopulationRepository
    {
        IQueryable<CityDataModel> _cities;
        IQueryable<CountryDataModel> _contries;
        IQueryable<StateDataModel> _states;

        public CountriesPopulationRepository(CountriesPopulationDbContext dbContext)
            : base(dbContext)
        {
            _cities = dbContext.Cities.AsQueryable();
            _contries = dbContext.Countries.AsQueryable();
            _states = dbContext.States.AsQueryable();
        }

        public IQueryable<CityDataModel> Cities => _cities;

        public IQueryable<CountryDataModel> Countries => _contries;

        public IQueryable<StateDataModel> States => _states;

        public override T GetById<T>(int id)
        {
            var items = _dbContext
                .Set<T>()
                .AsQueryable<T>();

            //var result = items.FirstOrDefault(item => item.Id.Equals(id));

            return null;

        }
    }
}
