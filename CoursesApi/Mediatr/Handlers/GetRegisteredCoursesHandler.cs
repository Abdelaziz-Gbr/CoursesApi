using AutoMapper;
using CoursesApi.Data.Repositories;
using CoursesApi.Mediatr.Queries;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class GetRegisteredCoursesHandler : IRequestHandler<GetRegisteredCourses, List<RegisteredCourseDto>>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;

        public GetRegisteredCoursesHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }
        public async Task<List<RegisteredCourseDto>> Handle(GetRegisteredCourses request, CancellationToken cancellationToken)
        {
            var registeredCoursesDomain = await courseRepository.GetRegisteredCoursesOfStudentAsync(request.userId);

            var courses = new List<RegisteredCourseDto>();
            foreach (StudentCourses c in registeredCoursesDomain) 
            {
                courses.Add(
                    new RegisteredCourseDto { CourseInfo = mapper.Map<CourseDto>(c.course),
                    Finished = c.Finished,
                    //put new grade
                    grade = c.Grade,
                    Passed = c.Passed,
                    RegisterationId = c.RegisterationId}
                    );
            }

            return courses;
        }
    }
}
