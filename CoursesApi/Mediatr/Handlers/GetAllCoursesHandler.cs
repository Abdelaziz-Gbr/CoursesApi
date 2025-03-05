using AutoMapper;
using CoursesApi.Data.Repositories;
using CoursesApi.Mediatr.Queries;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class GetAllCoursesHandler : IRequestHandler<GetAllCoursesQuery, List<CourseDto>>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;

        public GetAllCoursesHandler(ICourseRepository courseRepository, IMapper mapper)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
        }
        public async Task<List<CourseDto>> Handle(GetAllCoursesQuery request, CancellationToken cancellationToken)
        {
            var coursesDomain = await courseRepository.GetAllAvailableCoursesAsync();
            return mapper.Map<List<CourseDto>>(coursesDomain);
        }
    }
}
