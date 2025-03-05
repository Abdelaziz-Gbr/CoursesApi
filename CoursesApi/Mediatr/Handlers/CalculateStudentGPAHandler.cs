using CoursesApi.Data.Repositories;
using CoursesApi.Mediatr.Queries;
using CoursesApi.Models.Enums;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class CalculateStudentGPAHandler : IRequestHandler<CalculateStudentGPAQuery, double>
    {
        private readonly ICourseRepository _courseRepository;

        // Dictionary for grade-to-points mapping (faster lookup)
        private static readonly Dictionary<Grades, double> GradePoints = new()
        {
            { Grades.AP, 4.0 },
            { Grades.A, 3.7 },
            { Grades.BP, 3.3 },
            { Grades.B, 3.0 },
            { Grades.CP, 2.7 },
            { Grades.C, 2.4 },
            { Grades.DP, 2.2 },
            { Grades.D, 2.0 },
            { Grades.F, 0.0 }
        };

        public CalculateStudentGPAHandler(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<double> Handle(CalculateStudentGPAQuery request, CancellationToken cancellationToken)
        {
            var passedCourses = await _courseRepository.GetPassedCoursesOfStudentAsync(request.studentId);

            if (passedCourses is null || passedCourses.Count == 0)
                return 0.0;

            double totalPoints = 0;
            int totalCreditHours = 0;

            foreach (var course in passedCourses)
            {
                double gradePoints = GradePoints[course.Grade ?? Grades.F];
                int creditHours = course.course.CreditHours;

                totalPoints += gradePoints * creditHours;
                totalCreditHours += creditHours;
            }

            return totalCreditHours > 0 ? totalPoints / totalCreditHours : 0.0;
        }
    }
}
