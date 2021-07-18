using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using NUnit.Framework;
using QuickBase.Application.Countries.Queries.GetCountriesList;
using QuickBase.CountryApiClient;
using QuickBase.Persistence;
using System;
using System.Linq;
using System.Threading.Tasks;
using Models = QuickBase.Persistence.Models;

namespace QuickBase.Application.IntegrationTests
{
    public class GetCountriesListQueryIntegrationTest
    {
        ServiceProvider nurse;

        [SetUp]
        public void Setup()
        {
            var options = new DbContextOptionsBuilder<QuickBaseDbContext>()
                .UseInMemoryDatabase(Guid.NewGuid().ToString())
                .Options;

            var db = new QuickBaseDbContext(options);

            var services = new ServiceCollection();

            services.AddPersistence(db);
            services.AddCountryApiClient();
            services.AddApplication();

            nurse = services.BuildServiceProvider();
        }

        private async Task FillDb()
        {
            var db = nurse.GetService<QuickBaseDbContext>();
            await db.Countries.AddAsync(new Models.Country()
            {
                CountryId = 1,
                CountryName = "Cuba"
            });

            await db.Countries.AddAsync(new Models.Country()
            {
                CountryId = 2,
                CountryName = "United States of America"
            });

            await db.States.AddAsync(new Models.State()
            {
                StateId = 1,
                StateName = "Occidente",
                CountryId = 1
            });

            await db.States.AddAsync(new Models.State()
            {
                StateId = 2,
                StateName = "Florida",
                CountryId = 2
            });

            await db.Cities.AddAsync(new Models.City()
            {
                CityId = 1,
                CityName = "La Habana",
                StateId = 1,
                Population = 2000000
            });

            await db.Cities.AddAsync(new Models.City()
            {
                CityId = 2,
                CityName = "Miami",
                StateId = 2,
                Population = 3000000
            });

            await db.SaveChangesAsync();
        }


        [Test]
        public async Task TestAllSourcesShouldReturnRightCountries()
        {
            await FillDb();

            var mediator = nurse.GetService<IMediator>();
            var countriesVM = await mediator.Send(new GetCountriesListQuery());

            Assert.IsNotNull(countriesVM);
            Assert.IsTrue(countriesVM.Countries.Any(country => country.Name == "Cuba" && country.Population == 2000000));
            Assert.IsTrue(countriesVM.Countries.Any(country => country.Name == "U.S.A." && country.Population == 3000000));
        }
    }
}