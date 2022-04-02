using AuthenticationGrpc.Model;
using Microsoft.EntityFrameworkCore;

namespace AuthenticationGrpc.Db
{
    public class UserDbContext:DbContext
    {
        public DbSet<User>? users { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("server=(localdb)\\mssqllocaldb; database=user_db; integrated security=true");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
        }
    }
}
