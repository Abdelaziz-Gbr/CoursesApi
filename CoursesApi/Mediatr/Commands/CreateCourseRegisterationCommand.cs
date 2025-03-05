using MediatR;

namespace CoursesApi.Mediatr.Commands
{
    public record CreateCourseRegisterationCommand(Guid CourseId, Guid StudentId) : IRequest<Guid>;
}
