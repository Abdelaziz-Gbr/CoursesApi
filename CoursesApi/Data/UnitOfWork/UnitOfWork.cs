
using CoursesApi.Data.DbContexts;

namespace CoursesApi.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork, IDisposable
    {
        private readonly CourseDbContext dbContext;

        public UnitOfWork(CourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<int> CompleteAsync()
        {
            return await dbContext.SaveChangesAsync();
        }

        public void Dispose()
        {
            dbContext.Dispose();
        }
    }
}
