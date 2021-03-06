using Microsoft.EntityFrameworkCore;

namespace QuickBase.Demo.EntityFrameworkCore
{
    public static class DbContextOptionsConfigurer
    {
        public static void Configure(
            DbContextOptionsBuilder<DemoDbContext> dbContextOptions, 
            string connectionString
            )
        {
            /* This is the single point to configure DbContextOptions for DemoDbContext */
            dbContextOptions.UseSqlite(connectionString);
        }
    }
}
