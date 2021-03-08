using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using Application.Models;
using Application.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.Interfaces;
using Persistence.Models;

namespace Backend.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CountriesPopulationController : ControllerBase
    {
        private readonly ILogger<CountriesPopulationController> _logger;
        private readonly ICountriesPopulationService _countriesPopulationService;

        public CountriesPopulationController(ILogger<CountriesPopulationController> logger,
            ICountriesPopulationService countriesPopulationService)
        {
            _logger = logger;
            _countriesPopulationService = countriesPopulationService;
        }

        [HttpGet]
        public ActionResult<IEnumerable<CountriesPopulationResponseModel>> Get()
        {
            IEnumerable<CountriesPopulationResponseModel> result = null;
            _logger.LogInformation("Getting Countries Populeation");
            var sw = Stopwatch.StartNew();
            try
            {
                result = _countriesPopulationService.GetCountriesPopulation();

                sw.Stop();
                _logger.LogInformation($"Got Countries Population in {sw.Elapsed}");
            }
            catch (Exception ex)
            {
                sw.Stop();
                _logger.LogError($"Got Countries Population FAILED with {ex.Message}.\n Request took {sw.Elapsed}",
                    ex.StackTrace);
                return StatusCode(500, $"{nameof(ICountriesPopulationService)} failed to retrieve data.");
            }
            return result.ToList();
        }
    }
}
