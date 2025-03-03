using CoursesApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data.DbContexts
{
    public class CourseDbContext : DbContext
    {
        public CourseDbContext(DbContextOptions<CourseDbContext> options) : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<StudentCourses>().Property(x => x.Finished).HasDefaultValue(false);
            modelBuilder.Entity<StudentCourses>().Property(x => x.Passed).HasDefaultValue(false);
            modelBuilder.Entity<Course>().Property(x => x.Available).HasDefaultValue(true);
            modelBuilder.Entity<StudentCourses>().HasNoKey();
        }
        public DbSet<Course> Courses { get; set; }
        public DbSet<StudentCourses> StudentCourses { get; set; }
        public DbSet<Student> Students { get; set; }
        public DbSet<Lecturer> Lecturers { get; set; }
    }
}
