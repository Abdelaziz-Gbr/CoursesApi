using CoursesApi.Models.Dtos;
using MediatR;

namespace CoursesApi.Mediatr.Queries
{
    public record GetRegisteredCourses(Guid userId) : IRequest<List<RegisteredCourseDto>>;
}
