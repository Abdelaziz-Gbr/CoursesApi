using CoursesApi.Models.Dtos;
using MediatR;

namespace CoursesApi.Mediatr.Queries
{
    public record GetAllCoursesQuery() : IRequest<List<CourseDto>>;
}
