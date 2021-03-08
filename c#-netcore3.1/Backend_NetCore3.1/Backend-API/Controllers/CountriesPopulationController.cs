using System.Collections.Generic;
using Application.Models;
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
        private readonly IDataRepository _data;

        public CountriesPopulationController(ILogger<CountriesPopulationController> logger,
            IDataRepository data)
        {
            _logger = logger;
            _data = data;
        }

        [HttpGet]
        public IEnumerable<CountriesPopulationResponseModel> Get()
        {
            return null;
        }
    }
}
