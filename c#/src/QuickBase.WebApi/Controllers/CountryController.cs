using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using QuickBase.Application.Countries.Queries.GetCountriesList;
using QuickBase.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBase.WebApi.Controllers
{
    
    public class CountryController : QuickBaseController
    {
        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public async Task<CountriesListVM> GetAll()
        {
            return await Mediator.Send(new GetCountriesListQuery());
        }
    }
}
