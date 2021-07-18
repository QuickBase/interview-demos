using Microsoft.EntityFrameworkCore;
using QuickBase.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuickBase.Persistence
{
    public class QuickBaseDbContext : DbContext
    {
        public DbSet<Country> Countries { get; set; }

        public DbSet<State> States { get; set; }

        public DbSet<City> Cities { get; set; }

        public QuickBaseDbContext(DbContextOptions<QuickBaseDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(QuickBaseDbContext).Assembly);
        }
    }
}
