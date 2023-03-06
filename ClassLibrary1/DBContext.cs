using System.Data.Entity;

namespace ClassLibrary1
{
    public class DBContext : DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<Special> Specials { get; set; }
        public DbSet<Group> Groups { get; set; }
    }
}
