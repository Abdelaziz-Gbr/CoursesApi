using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations.Schema;

namespace CoursesApi.Models.Data
{
    public class Student
    {
        public Guid Id { get; set; }

        public string Email { get; set; }

        public string FullName { get; set; }

    }
}
