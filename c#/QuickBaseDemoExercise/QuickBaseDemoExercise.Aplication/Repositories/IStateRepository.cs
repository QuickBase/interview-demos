using QuickBaseDemoExercise.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Repositories
{
    public interface IStateRepository
    {
        Task<IEnumerable<State>> Get();

        Task<State> Get(int id);

    }
}
