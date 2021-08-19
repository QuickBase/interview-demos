using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly citystatecountryContext _context;
        public CityRepository(citystatecountryContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<City>> Get()
        {
            return await _context.Cities.ToListAsync();
        }

        public async Task<City> Get(int id)
        {
            return await _context.Cities.FindAsync(id);
        }
    }
}
