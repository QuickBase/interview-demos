using NUnit.Framework;
using Moq;
using QuickBase.Domain.Repositories;
using System.Threading.Tasks;
using QuickBase.Domain.Entities;
using System.Collections.Generic;
using QuickBase.Application.Common.DataNormalizer;
using QuickBase.Application.Common.Repositories;
using QuickBase.Application.Common.Comparers;
using System.Linq;

namespace QuickBase.Application.UnitTests
{
    public class CountrySourcesRepositoryUnitTest
    {
        Mock<ICountryNameNormalizer> countryNameNormalizerMock;

        [SetUp]
        public void Setup()
        {
            countryNameNormalizerMock = new Mock<ICountryNameNormalizer>();
            countryNameNormalizerMock.Setup(x => x.NormalizeName(It.IsAny<string>()))
                .Returns((string countryName) => countryName);
        }

        [Test]
        public async Task GetCountriesShouldRespectSourcesOrder()
        {
            var databaseRepoMock = new Mock<ICountryDatabaseRepository>();
            databaseRepoMock.Setup(x => x.GetCountries()).ReturnsAsync(new List<Country>()
            {
                new Country() { Name = "country1", Population = 1 }
            });

            var apiRepoMock = new Mock<ICountryApiRepository>();
            apiRepoMock.Setup(x => x.GetCountries()).ReturnsAsync(new List<Country>()
            {
                new Country() { Name = "country1", Population = 2 }
            });

            var sourcesRepo = new CountrySourcesRepository(
                apiRepoMock.Object,
                databaseRepoMock.Object,
                new CountryEqualityComparer(),
                countryNameNormalizerMock.Object
                );

            var countries = await sourcesRepo.GetCountries();

            Assert.NotNull(countries);
            Assert.AreEqual(countries.Count, 1);
            Assert.AreEqual(countries.First().Population, 1);
        }
    }
}