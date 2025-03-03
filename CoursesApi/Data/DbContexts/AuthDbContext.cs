using CoursesApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data.DbContexts
{
    public class AuthDbContext : DbContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // store role data as string.
            modelBuilder.Entity<User>().Property(user => user.Role).HasConversion<string>();
        }
    }
}
