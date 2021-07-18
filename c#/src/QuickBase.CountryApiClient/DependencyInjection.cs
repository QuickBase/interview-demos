using Microsoft.Extensions.DependencyInjection;
using QuickBase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.CountryApiClient
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddCountryApiClient(this IServiceCollection services)
        {
            services.AddScoped<ICountryApiRepository, MockCountryRepository>();
            return services;
        }
    }
}
