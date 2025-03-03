using CoursesApi.Models.Data;
using CoursesApi.Models.Enums;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models.Dtos
{
    public class UserRegisterDto
    {
        [Required]
        public string FullName { get; set; }

        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }
        [Required]
        public string Role { get; set; }
    }
}
