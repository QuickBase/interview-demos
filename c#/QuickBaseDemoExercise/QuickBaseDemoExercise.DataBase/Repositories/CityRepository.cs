using Microsoft.EntityFrameworkCore;
using QuickBaseDemoExercise.DataBase.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBaseDemoExercise.DataBase.Repositories
{
    public class CityRepository : ICityRepository
    {
        private readonly citystatecountryContext _context;
        public CityRepository(citystatecountryContext context)
        {
            _context = context;
        }
        public  Task<DbSet<City>> Get()
        {
            return Task.FromResult(_context.Cities);
        }

    }
}
