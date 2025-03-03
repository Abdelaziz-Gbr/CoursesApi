using CoursesApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models.Data
{
    public class User
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public string HashedPassword { get; set; }

        public UserType Role{ get; set; }

    }
}
