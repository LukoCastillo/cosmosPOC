using Microsoft.EntityFrameworkCore;


namespace POC_Redis.Data
{
    public class POCDBContext : DbContext
    {
        public POCDBContext(DbContextOptions<POCDBContext> options)
        : base(options)
        {
        }

        public DbSet<KeyValue> KeyValues { get; set; }
    }
}
