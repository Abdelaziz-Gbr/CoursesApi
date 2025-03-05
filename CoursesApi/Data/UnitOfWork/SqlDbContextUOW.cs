
using CoursesApi.Data.DbContexts;

namespace CoursesApi.Data.UnitOfWork
{
    public class SqlDbContextUOW : IUnitOfWork, IDisposable
    {
        private readonly CourseDbContext courseDbContext;
        private readonly AuthDbContext authDbContext;

        public SqlDbContextUOW(CourseDbContext dbContext, AuthDbContext authDbContext)
        {
            this.courseDbContext = dbContext;
            this.authDbContext = authDbContext;
        }
        public async Task<int> CompleteAsync()
        {
            int r1 = await courseDbContext.SaveChangesAsync();
            int r2 = await authDbContext.SaveChangesAsync();
            return r1 + r2;
        }

        public void Dispose()
        {
            courseDbContext.Dispose();
        }
    }
}
