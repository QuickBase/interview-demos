using System;
using System.Collections.Generic;
using System.Linq;
using Domain;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesPopulationController : ControllerBase
    {
        private readonly ILogger<CountriesPopulationController> _logger;

        public CountriesPopulationController(ILogger<CountriesPopulationController> logger)
        {
            _logger = logger;
        }

        [HttpGet]
        public IEnumerable<CountryPopulation> Get()
        {
            return null;
        }
    }
}
