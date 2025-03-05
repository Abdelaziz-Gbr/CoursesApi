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

        public async Task AddStudentAsync(Student student)
        {
            await dbContext.Students.AddAsync(student);
        }

        public async Task<List<Course>> GetAllAvailableCoursesAsync()
        {
            return await dbContext.Courses
                .Include(course => course.CourseLecturer)
                .Where(course => course.Available == true)
                .ToListAsync();
        }

        public async Task<List<StudentCourses>> GetPassedCoursesOfStudentAsync(Guid StudentId)
        {
            var passedCourses = await dbContext.StudentCourses
                .Include(r => r.course)
                .Where(r => r.StudentId == StudentId)
                .Where(r => r.Passed == true)
                .ToListAsync();
            return passedCourses;
        }

        public async Task<List<StudentCourses>> GetRegisteredCoursesOfStudentAsync(Guid StudentId)
        {
            var registeredCourses = await dbContext.StudentCourses
                .Include(s => s.course)
                .Where(reg => reg.StudentId == StudentId)
                .ToListAsync();
           return registeredCourses;
        }

        public async Task<StudentCourses?> GetStudentCourseByIdAsync(Guid studentId, Guid courseId)
        {
            return await dbContext.StudentCourses
                .FirstOrDefaultAsync(sc => sc.StudentId == studentId && sc.CourseId == courseId);
        }


        public async Task<Guid> RegisterCourseAsync(Guid courseId, Guid StudentId)
        {
            var CourseRegisteration = new StudentCourses
            {
                RegisterationId = Guid.NewGuid(),
                CourseId = courseId,
                StudentId = StudentId,
                Finished = false,
                Passed = false
            };
            await dbContext.StudentCourses.AddAsync(CourseRegisteration);
            return CourseRegisteration.RegisterationId;
        }
    }
}
