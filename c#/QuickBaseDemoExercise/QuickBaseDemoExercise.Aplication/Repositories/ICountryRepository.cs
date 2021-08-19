using QuickBaseDemoExercise.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Repositories
{
    public interface ICountryRepository
    {
        Task<IEnumerable<Country>> Get();

        Task<Country> Get(int id);

    }
}
