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
    public class CitiesController : ControllerBase
    {
        private readonly ICityRepository _cityRepository;
        public CitiesController(ICityRepository cityRepository)
        {
            _cityRepository = cityRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<City>> GetCities()
        {
            return await _cityRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<City>> GetCity([FromBody] int id)
        {
            return await _cityRepository.Get(id);
        }
    }
}
