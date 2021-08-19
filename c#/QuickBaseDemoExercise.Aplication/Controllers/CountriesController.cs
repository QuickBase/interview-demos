using Microsoft.AspNetCore.Mvc;
using QuickBaseDemoExercise.Domain;
using QuickBaseDemoExercise.Services;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryService _countryService;
        public CountriesController(ICountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetCities()
        {
            return await _countryService.GetCountries();
        }

    }
}
