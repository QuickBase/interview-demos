using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Concrete
{
    public class CountriesPopulationDbContext : DbContext
    {
        public DbSet<CityDataModel> Cities { get; set; }
        public DbSet<CountryDataModel> Countries { get; set; }
        public DbSet<StateDataModel> States { get; set; }

        public CountriesPopulationDbContext() : base()
        {
        }
    }
}
