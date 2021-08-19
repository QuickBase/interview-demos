using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Repositories
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

        public async Task<State> Get(int id)
        {
            return await _context.States.FindAsync(id);
        }
    }
}
