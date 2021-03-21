using Microsoft.EntityFrameworkCore;

namespace PastryShop.DAL
{
    public class PastrySqliteDBContext : PastryDbContext
    {
        public PastrySqliteDBContext()
        {
        }

        public PastrySqliteDBContext(DbContextOptions<PastrySqliteDBContext> options) : base(options)
        {
        }

#if DEBUG_EF
        protected override void OnConfiguring(DbContextOptionsBuilder options)
        {
            options.UseSqlite("DataSource=");
        }
#endif
    }
}