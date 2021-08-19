using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBaseDemoExercise.Aplication.Models;
using QuickBaseDemoExercise.Aplication.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountriesController : ControllerBase
    {
        private readonly ICountryRepository _countryRepository;
        public CountriesController(ICountryRepository countryRepository)
        {
            _countryRepository = countryRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Country>> GetCities()
        {
            return await _countryRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Country>> GetCity(int id)
        {
            return await _countryRepository.Get(id);
        }
    }
}
