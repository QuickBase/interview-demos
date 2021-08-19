using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.DataBase.Repositories
{
    public class StateRepository : IStateRepository
    {
        private readonly citystatecountryContext _context;
        public StateRepository(citystatecountryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<State>> Get()
        {
            return await _context.States.ToListAsync();
        }

    }
}
