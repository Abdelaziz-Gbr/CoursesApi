using CoursesApi.Models.Enums;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesApi.Models.Data
{
    public class StudentCourses
    {
        [Key]
        public Guid RegisterationId { get; set; }

        [ForeignKey("student")]
        public Guid StudentId { get; set; }

        [ForeignKey("course")]
        public Guid CourseId { get; set; }


        [Column(TypeName = "nvarchar(10)")]
        public Grades? Grade { get; set; }

        public bool Finished { get; set; }

        public bool Passed { get; set; }

        public Student student { get; set; }

        public Course course { get; set; }
    }
}
