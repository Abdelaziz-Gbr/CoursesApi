using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Models.Dtos
{
    public class UserLogInDto
    {
        [Required]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

    }
}
