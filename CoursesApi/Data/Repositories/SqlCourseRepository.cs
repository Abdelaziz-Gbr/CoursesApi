using CoursesApi.Data.DbContexts;
using CoursesApi.Data.UnitOfWork;
using CoursesApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data.Repositories
{
    public class SqlCourseRepository : ICourseRepository
    {
        private readonly CourseDbContext dbContext;

        public SqlCourseRepository(CourseDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<Course> AddCourseAsync(Course course)
        {
            await dbContext.Courses.AddAsync(course);
            return course;
        }

        public async Task<Lecturer> AddLecturerAsync(Lecturer lecturer)
        {
            await dbContext.Lecturers.AddAsync(lecturer);
            return lecturer;
        }

    }
}
