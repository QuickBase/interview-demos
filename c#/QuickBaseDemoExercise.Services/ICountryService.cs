using QuickBaseDemoExercise.Domain;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Services
{
    public interface ICountryService
    {
        Task<List<Country>> GetCountries();
    }
}
