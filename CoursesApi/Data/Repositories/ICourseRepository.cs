using CoursesApi.Models.Data;

namespace CoursesApi.Data.Repositories
{
    public interface ICourseRepository
    {
        Task<Course> AddCourseAsync(Course course);

        Task<Lecturer> AddLecturerAsync(Lecturer lecturer);
    }
}
