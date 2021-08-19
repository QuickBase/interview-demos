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
    public class StatesController : ControllerBase
    {
        private readonly IStateRepository _stateRepository;
        public StatesController(IStateRepository stateRepository)
        {
            _stateRepository = stateRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<State>> GetCities()
        {
            return await _stateRepository.Get();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<State>> GetCity(int id)
        {
            return await _stateRepository.Get(id);
        }
    }
}
