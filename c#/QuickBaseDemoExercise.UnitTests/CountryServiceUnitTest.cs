using Moq;
using NUnit.Framework;
using QuickBaseDemoExercise.Domain;
using QuickBaseDemoExercise.Services;
using QuickBaseDemoExercise.Services.Implementations;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.UnitTests
{
    public class CountryServiceUnitTest
    {
       private  Mock<ICountryIdFactory> countryIdFactoryMock;
       

        [SetUp]
        public void Setup()
        {
            countryIdFactoryMock = new Mock<ICountryIdFactory>();
            countryIdFactoryMock.Setup(x => x.BuildId(It.IsAny<Country>()))
                .Returns((Country country) => country.Name);

        }

        [Test]
        public async Task Test1()
        {
            Mock<ICountrySourceService> source1 = new Mock<ICountrySourceService>();
            source1.Setup(x => x.Order)
                .Returns(1);
            source1.Setup(x => x.GetCountries())
                .Returns(Task.FromResult(new List<Country>()
                {
                    new Country() { Name = "a", Population = 3 },
                }));

            Mock<ICountrySourceService> source2 = new Mock<ICountrySourceService>();
            source2.Setup(x => x.Order)
                .Returns(2);
            source2.Setup(x => x.GetCountries())
                .Returns(Task.FromResult(new List<Country>()
                {
                    new Country() { Name = "a", Population = 4 },
                }));


            Mock<ISourcesService> sourcesFactoryMock = new Mock<ISourcesService>();
            sourcesFactoryMock.Setup(x => x.GetCountrySources())
                .Returns(new List<ICountrySourceService>()
                {
                    source2.Object, source1.Object
                });

            CountryService countryService = new CountryService(new CountryComparer(),
                sourcesFactoryMock.Object,
                countryIdFactoryMock.Object);

            var countries = await countryService.GetCountries();
            
            Assert.AreEqual(countries.First().Population, 3);
            Assert.AreEqual(countries.Count, 1);
        }
    }
}