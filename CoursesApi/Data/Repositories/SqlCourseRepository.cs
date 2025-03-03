using CoursesApi.Data.DbContexts;
using CoursesApi.Data.UnitOfWork;
using CoursesApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data.Repositories
{
    public class SqlCourseRepository : ICourseRepository
    {
        private readonly CourseDbContext dbContext;
        private readonly IUnitOfWork unitOfWork;

        public SqlCourseRepository(CourseDbContext dbContext, IUnitOfWork unitOfWork)
        {
            this.dbContext = dbContext;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Course> AddCourse(Course course)
        {
            dbContext.Courses.Add(course);
            await unitOfWork.CompleteAsync();
            return course;
        }

        public async Task<Lecturer> AddLecturer(Lecturer lecturer)
        {
            dbContext.Lecturers.Add(lecturer);
            await unitOfWork.CompleteAsync();
            return lecturer;
        }

        public async Task<List<Course>> GetAll()
        {
            return await dbContext.Courses.ToListAsync();

        }

        public async Task<Course?> GetById(Guid Id)
        {
            return await dbContext.Courses.FirstOrDefaultAsync(x => x.Id == Id);
        }

        public async Task<Course?> GetByName(string CourseName)
        {
            return await dbContext.Courses.FirstOrDefaultAsync(x => x.CourseName == CourseName);
        }
    }
}
