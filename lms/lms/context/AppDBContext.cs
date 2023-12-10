using lms.Models;
using Microsoft.EntityFrameworkCore;

namespace lms.context
{
    public class AppDBContext : DbContext
    {
        public AppDBContext(DbContextOptions<AppDBContext> options) : base(options) { }

        public DbSet<user> Users { get; set; }
        public DbSet<book> Books { get; set; }
        public DbSet<order> Orders { get; set; }
    }
}
