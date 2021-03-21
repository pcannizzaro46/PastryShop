using Microsoft.EntityFrameworkCore;

namespace PastryShop.DAL
{
    public class PastrySqlServerDBContext : PastryDbContext
    {
        public PastrySqlServerDBContext()
        {
        }

        public PastrySqlServerDBContext(DbContextOptions<PastrySqlServerDBContext> options) : base(options)
        {
        }

#if DEBUG_EF
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            //options.UseSqlServer("DataSource=");
            //options.UseSqlServer("server=(localdb)\\MSSQLLocalDB;database=Pastry;Trusted_Connection=true");
        }
#endif
    }
}