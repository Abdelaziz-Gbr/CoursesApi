using MediatR;

namespace CoursesApi.Mediatr.Commands
{
    public record CreateLecturerCommand(string name, string email) : IRequest<Guid>;
}
