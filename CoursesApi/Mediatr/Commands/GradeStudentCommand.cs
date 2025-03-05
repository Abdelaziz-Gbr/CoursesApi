using CoursesApi.Models.Enums;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace CoursesApi.Mediatr.Commands
{
    public record GradeStudentCommand(
        [Required] Guid studentId,
        [Required] Guid courseId,
        [Required] Grades grade) : IRequest<Guid>;
}
