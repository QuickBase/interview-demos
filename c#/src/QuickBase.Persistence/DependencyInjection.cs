using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using QuickBase.Domain.Repositories;
using QuickBase.Persistence.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Persistence
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPersistence(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<QuickBaseDbContext>(options =>
                options.UseSqlite(configuration.GetConnectionString("QuickBaseDatabase")));

            services.AddScoped<ICountryDatabaseRepository, CountryRepository>();

            return services;
        }
    }
}
