using CoursesApi.Models.Data;

namespace CoursesApi.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course);

        Task<Lecturer> AddLecturerAsync(Lecturer lecturer);

        Task<List<Course>> GetAllAvailableCoursesAsync();

        Task<Guid> RegisterCourseAsync(Guid courseId, Guid StudentId);

        Task AddStudentAsync(Student student);

        Task<List<StudentCourses>> GetRegisteredCoursesOfStudentAsync(Guid StudentId);
        Task<List<StudentCourses>> GetPassedCoursesOfStudentAsync(Guid StudentId);

        Task<StudentCourses?> GetStudentCourseByIdAsync(Guid studentId, Guid courseId);
    }
}
