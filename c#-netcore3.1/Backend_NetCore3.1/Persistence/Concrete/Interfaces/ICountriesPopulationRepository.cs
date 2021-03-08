using Persistence.Models;
using System.Linq;

namespace Persistence.Concrete.Interfaces
{
    public interface ICountriesPopulationRepository
    {
        public IQueryable<CityDataModel> Cities { get; }
        public IQueryable<CountryDataModel> Countries { get; }
        public IQueryable<StateDataModel> States { get; }
    }
}
