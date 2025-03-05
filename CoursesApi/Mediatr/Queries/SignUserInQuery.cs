using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Mediatr.Queries
{
    public record SignUserInQuery(
        [Required, EmailAddress] string Email,
        [Required, DataType(DataType.Password)] string Password) :  IRequest<string>;
}
