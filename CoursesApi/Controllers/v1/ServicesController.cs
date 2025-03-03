using Asp.Versioning;
using AutoMapper;
using CoursesApi.Data.Repositories;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServicesController : ControllerBase
    {
        private readonly ICourseRepository courseRepository;
        private readonly IMapper mapper;
        private readonly ILogger logger;

        public ServicesController(ICourseRepository courseRepository, 
            IMapper mapper,
            ILogger<ServicesController> logger)
        {
            this.courseRepository = courseRepository;
            this.mapper = mapper;
            this.logger = logger;
        }
        [HttpGet("courses")]
        [Authorize(Roles = "STUDENT")]
        public IActionResult GetAllAvailableCourses()
        {
            return Ok("cs-it-ai-is-ds");
        }

        [HttpPost("courses")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddCourse([FromBody] AddCourseDto addCourseDto)
        {
            var courseDomainModel = mapper.Map<Course>(addCourseDto);
            courseDomainModel = await courseRepository.AddCourse(courseDomainModel);
            return Ok(mapper.Map<CourseDto>(courseDomainModel));
        }

        [HttpPost("lecturers")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddLecturer([FromBody] AddLecturerDto addLecturerDto)
        {
            var lecturerDomainModel = mapper.Map<Lecturer>(addLecturerDto);
            lecturerDomainModel.Id = Guid.NewGuid();
            lecturerDomainModel = await courseRepository.AddLecturer(mapper.Map<Lecturer>(addLecturerDto));
            return Ok(mapper.Map<LecturerDto>(lecturerDomainModel));
        }
    }
}
