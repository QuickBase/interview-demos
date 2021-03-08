using Application.Models;
using System.Collections.Generic;

namespace Application.Services.Interfaces
{
    public interface ICountriesPopulationService
    {
        IEnumerable<CountriesPopulationResponseModel> GetCountriesPopulation();
    }
}
