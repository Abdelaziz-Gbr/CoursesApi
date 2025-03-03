namespace CoursesApi.Models.Data
{
    public class Course
    {
        public Guid Id { get; set; }

        public string CourseName { get; set; }

        public bool Available { get; set; }

        public Guid LecturerId { get; set; }


        public Lecturer CourseLecturer { get; set; }

    }
}
