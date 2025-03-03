using CoursesApi.Models.Data;

namespace CoursesApi.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<List<Course>> GetAll();

        Task<Course?> GetById(Guid Id);

        Task<Course?> GetByName(string Name);

        Task<Course> AddCourse(Course course);

        Task<Lecturer> AddLecturer(Lecturer lecturer);
    }
}
