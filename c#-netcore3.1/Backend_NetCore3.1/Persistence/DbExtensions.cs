using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Concrete;

namespace Persistence
{
    public static class DbExtensions
    {
        public static void AddCountriesDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<CountriesPopulationDbContext>(options => options.UseSqlite(connectionString));
        }
    }
}
