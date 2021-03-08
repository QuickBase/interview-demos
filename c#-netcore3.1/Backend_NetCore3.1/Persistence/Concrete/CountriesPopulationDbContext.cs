using Microsoft.EntityFrameworkCore;
using Persistence.Models;

namespace Persistence.Concrete
{
    public class CountriesPopulationDbContext : DbContext
    {
        public DbSet<CityDataModel> Cities { get; set; }
        public DbSet<CountryDataModel> Countries { get; set; }
        public DbSet<StateDataModel> States { get; set; }

        public CountriesPopulationDbContext(DbContextOptions options)
            : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CityDataModel>(city =>
            {
                city.HasKey(c => c.CityId);
                city.Property(c => c.CityName);
                city.Property(c => c.Population);
                city.Property(c => c.StateId);
                city.ToTable("City");
            });

            modelBuilder.Entity<CountryDataModel>(country =>
            {
                country.HasKey(c => c.CountryId);
                country.Property(c => c.CountryName);
                country.ToTable("Country");
            });

            modelBuilder.Entity<StateDataModel>(state =>
            {
                state.HasKey(s => s.StateId);
                state.Property(s => s.CountryId);
                state.Property(s => s.StateName);
                state.ToTable("State");
            });
        }
    }
}
