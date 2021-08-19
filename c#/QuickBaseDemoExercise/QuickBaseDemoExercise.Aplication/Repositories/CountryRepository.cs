using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.Aplication.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.Aplication.Repositories
{
    public class CountryRepository : ICountryRepository
    {
        private readonly citystatecountryContext _context;
        public CountryRepository(citystatecountryContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Country>> Get()
        {
            return await _context.Countries.ToListAsync();
        }

        public async Task<Country> Get(int id)
        {
            return await _context.Countries.FindAsync(id);
        }
    }
}
