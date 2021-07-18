using Microsoft.Extensions.DependencyInjection;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;
using QuickBase.Domain.Repositories;
using QuickBase.Application.Common.Repositories;
using QuickBase.Domain.Entities;
using QuickBase.Application.Common.Comparers;
using QuickBase.Application.Common.Mappings;
using QuickBase.Application.Common.DataNormalizer;

namespace QuickBase.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            var assembly = Assembly.GetExecutingAssembly();

            services.AddAutoMapper(typeof(MappingProfile));
            services.AddMediatR(assembly);
            services.AddScoped<ICountryRepository, CountrySourcesRepository>();
            services.AddScoped<IEqualityComparer<Country>, CountryEqualityComparer>();
            services.AddScoped<ICountryNameNormalizer, CountryNameNormalizer>();

            return services;
        }
    }
}
