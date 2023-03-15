using Domain;
using Microsoft.EntityFrameworkCore;

namespace Persistence
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
            
        }

        // we create db sets which represent the tables that we create
        public DbSet<Activity> Activities { get; set; } //will represent table name in DB when it'll be created

    }
}