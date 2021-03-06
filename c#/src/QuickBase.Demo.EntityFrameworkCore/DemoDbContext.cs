using Abp.Domain.Repositories;
using Abp.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using QuickBase.Demo.Domain.Models;
using QuickBase.Demo.EntityFrameworkCore.Configurations;
using QuickBase.Demo.EntityFrameworkCore.Repositories;

namespace QuickBase.Demo.EntityFrameworkCore
{
    [AutoRepositoryTypes(
        typeof(IRepository<>),
        typeof(IRepository<,>),
        typeof(BaseRepository<>),
        typeof(BaseRepository<,>)
    )]
    public class DemoDbContext : AbpDbContext
    {
        public DbSet<Country> Countries { get; set; }
        public DbSet<State> States { get; set; }
        public DbSet<City> Cities { get; set; }

        public DbSet<CountryPopulation> CountriesPopulation { get; set; }


    public DemoDbContext(DbContextOptions<DemoDbContext> options) 
            : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder
                .ApplyConfiguration(new CountryConfiguration())
                .ApplyConfiguration(new StateConfiguration())
                .ApplyConfiguration(new CityConfiguration())
                .ApplyConfiguration(new CountryPopulationConfiguration());
        }

    }
}
