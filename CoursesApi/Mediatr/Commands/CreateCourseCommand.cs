using MediatR;

namespace CoursesApi.Mediatr.Commands
{
    public record CreateCourseCommand(string CourseName, Guid LecturerId) : IRequest<Guid>;
}
