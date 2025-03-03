using CoursesApi.Models.Data;

namespace CoursesApi.Models.Dtos
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string CourseName { get; set; }
        public Lecturer CourseLecturer { get; set; }
    }
}
