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
        private readonly QuickBaseDemoContext _context;
        public CountryRepository(QuickBaseDemoContext context)
        {
            _context = context;
        }

        public DbSet<Country> Get()
        {
            return _context.Countries;
        }

     }
}
