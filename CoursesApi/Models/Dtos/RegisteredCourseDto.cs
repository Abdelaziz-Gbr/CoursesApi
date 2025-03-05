using CoursesApi.Models.Enums;

namespace CoursesApi.Models.Dtos
{
    public class RegisteredCourseDto
    {
        public CourseDto CourseInfo { get; set; }
        public Guid RegisterationId { get; set; }
        public Grades? grade { get; set; }

        public bool Finished { get; set; }

        public bool Passed { get; set; }

    }
}
