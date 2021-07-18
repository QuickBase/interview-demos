using QuickBase.Domain.Entities;
using QuickBase.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.CountryApiClient
{
    public class MockCountryRepository : ICountryApiRepository
    {
        public Task<List<Country>> GetCountries()
        {
            return Task.FromResult(new List<Country>()
            {
                new Country() { Name = "India", Population = 1182105000 },
                new Country() { Name = "United Kingdom", Population = 62026962 },
                new Country() { Name = "Chile", Population = 17094270 },
                new Country() { Name = "Mali", Population = 15370000 },
                new Country() { Name = "Greece", Population = 11305118 },
                new Country() { Name = "Armenia", Population = 3249482 },
                new Country() { Name = "Slovenia", Population = 2046976 },
                new Country() { Name = "Saint Vincent and the Grenadines", Population = 109284 },
                new Country() { Name = "Bhutan", Population = 695822 },
                new Country() { Name = "Aruba (Netherlands)", Population = 101484 },
                new Country() { Name = "Maldives", Population = 319738 },
                new Country() { Name = "Mayotte (France)", Population = 202000 },
                new Country() { Name = "Vietnam", Population = 86932500 },
                new Country() { Name = "Germany", Population = 81802257 },
                new Country() { Name = "Botswana", Population = 2029307 },
                new Country() { Name = "Togo", Population = 6191155 },
                new Country() { Name = "Luxembourg", Population = 502066 },
                new Country() { Name = "U.S. Virgin Islands (US)", Population = 106267 },
                new Country() { Name = "Belarus", Population = 9480178 },
                new Country() { Name = "Myanmar", Population = 59780000 },
                new Country() { Name = "Mauritania", Population = 3217383 },
                new Country() { Name = "Malaysia", Population = 28334135 },
                new Country() { Name = "Dominican Republic", Population = 9884371 },
                new Country() { Name = "New Caledonia (France)", Population = 248000 },
                new Country() { Name = "Slovakia", Population = 5424925 },
                new Country() { Name = "Kyrgyzstan", Population = 5418300 },
                new Country() { Name = "Lithuania", Population = 3329039 },
                new Country() { Name = "United States of America", Population = 309349689 }
            });
        }
    }
}
