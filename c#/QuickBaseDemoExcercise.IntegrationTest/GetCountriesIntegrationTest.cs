using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using QuickBaseDemoExercise.DataBase;
using QuickBaseDemoExercise.DataBase.Models;
using QuickBaseDemoExercise.DataBase.Repositories;
using QuickBaseDemoExercise.Services;
using QuickBaseDemoExercise.Services.Implementations;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Domain = QuickBaseDemoExercise.Domain;

namespace QuickBaseDemoExcercise.IntegrationTest
{
    public class GetCountriesIntegrationTest
    {
        ServiceProvider srvProvider;

        [SetUp]
        public void Setup()
        {
            var opts = new DbContextOptionsBuilder<QuickBaseDemoContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var dataBase = new QuickBaseDemoContext(opts);

            var services = new ServiceCollection();

            services.AddScoped(srvProvider => dataBase);
            services.AddScoped<CountryApiService>();
            services.AddScoped<CountryDbService>();
            services.AddScoped<IEqualityComparer<Domain.Country>, CountryComparer>();
            services.AddScoped<ICountryRepository, CountryRepository>();
            services.AddScoped<ICountryService, CountryService>();
            services.AddScoped<ICountryIdFactory, CountryIdFactory>();
            services.AddScoped<ISourcesService, SourcesService>();

            srvProvider = services.BuildServiceProvider();

        }

        [Test]
        public async Task ReturnAllCorrectCountriesTest()
        {
            await PopulateDb();

            var service = srvProvider.GetService<ICountryService>();
            var countries = await service.GetCountries();

            Assert.IsNotNull(countries);
            Assert.IsTrue(countries.Any(country => country.Name == "Bulgaria" && country.Population == 1000000));
            Assert.IsTrue(countries.Any(country => country.Name == "France" && country.Population == 3000000));
        }

        private async Task PopulateDb()
        {
            var dataBase = srvProvider.GetService<QuickBaseDemoContext>();

            await dataBase.Countries.AddAsync(new Country()
            {
                CountryId = 1,
                CountryName = "Bulgaria"
            });   
            
            await dataBase.Countries.AddAsync(new Country()
            {
                CountryId = 2,
                CountryName = "France"
            });      
            
            await dataBase.States.AddAsync(new State()
            {
                CountryId = 1,
                StateName = "Sofia",
                StateId = 1
            }); 
            
            await dataBase.States.AddAsync(new State()
            {
                CountryId = 2,
                StateName = "Paris",
                StateId = 2
            });     
            
            await dataBase.Cities.AddAsync(new City()
            {
                CityId = 1,
                CityName = "Sofia",
                StateId = 1,
                Population = 1000000
            }); 
            
            await dataBase.Cities.AddAsync(new City()
            {
                CityId = 2,
                CityName = "Paris",
                StateId = 2,
                Population = 3000000
            });

            await dataBase.SaveChangesAsync();
        }
    }
}