using CoursesApi.Models.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Mediatr.Commands
{
    public record CreateUserCommand(
            [Required] string FullName,
            [Required, EmailAddress] string Email,
            [Required] string Password,
            [Required] UserType Role) : IRequest<bool>;
}
