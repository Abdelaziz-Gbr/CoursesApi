using CoursesApi.Models.Data;

namespace CoursesApi.Models.Dtos
{
    public class AddCourseDto
    {
        public string CourseName { get; set; }
        public bool Available { get; set; }
        public Guid LecturerId { get; set; }
    }
}
