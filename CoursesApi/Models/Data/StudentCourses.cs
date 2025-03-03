using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesApi.Models.Data
{
    public class StudentCourses
    {
        [ForeignKey("student")]
        public Guid StudentId { get; set; }

        [ForeignKey("course")]
        public Guid CourseId { get; set; }

        public float? grade { get; set; }

        public bool Finished { get; set; }

        public bool Passed { get; set; }

        public Student student { get; set; }

        public Course course { get; set; }
    }
}
