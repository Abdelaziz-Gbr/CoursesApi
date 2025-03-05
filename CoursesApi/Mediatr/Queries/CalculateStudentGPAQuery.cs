using MediatR;

namespace CoursesApi.Mediatr.Queries
{
    public record CalculateStudentGPAQuery(Guid studentId) : IRequest<double>;
}
