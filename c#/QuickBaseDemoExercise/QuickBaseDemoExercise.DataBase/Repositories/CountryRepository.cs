using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.DataBase.Repositories
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

     }
}
