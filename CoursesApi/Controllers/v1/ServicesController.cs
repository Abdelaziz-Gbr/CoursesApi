using Asp.Versioning;
using AutoMapper;
using CoursesApi.Data.Repositories;
using CoursesApi.Mediatr.Commands;
using CoursesApi.Mediatr.Queries;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace CoursesApi.Controllers.v1
{
    [ApiController]
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiVersion("1.0")]
    public class ServicesController : ControllerBase
    {
        private readonly ISender sender;

        public ServicesController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet("courses")]
        [Authorize(Roles = "STUDENT")]
        public async Task<IActionResult> GetAllAvailableCourses()
        {
            var courses = await sender.Send(new GetAllCoursesQuery()); 
            return Ok(courses);
        }

        [HttpPost("register-course")]
        [Authorize(Roles = "STUDENT")]
        public async Task<IActionResult> RegisterCourseForStudent([FromBody] Guid courseId)
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var registerationRequest = new CreateCourseRegisterationCommand(courseId, userId);
            var result = await sender.Send(registerationRequest);
            return Ok(result);
        }

        [HttpGet("register-course")]
        [Authorize(Roles = "STUDENT")]
        public async Task<IActionResult> GetRegisteredCourses()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var GetRegistedredQuery = new GetRegisteredCourses(userId);
            var result = await sender.Send(GetRegistedredQuery);
            return Ok(result);
        }

        [HttpGet("gpa")]
        [Authorize(Roles = "STUDENT")]
        public async Task<IActionResult> GetStudentGpa()
        {
            var userId = Guid.Parse(User.FindFirstValue(ClaimTypes.NameIdentifier));

            var calculateGPAQuery = new CalculateStudentGPAQuery(userId);
            var gpa = await sender.Send(calculateGPAQuery);
            return Ok(gpa);
        }


        [HttpPost("courses")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddCourse([FromBody] CreateCourseCommand createCourseCommand)
        {
            var courseId = await sender.Send(createCourseCommand);
            return Ok($"CourseId:{courseId}");
        }

        [HttpPost("lecturers")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> AddLecturer([FromBody] CreateLecturerCommand createLecturerCommand)
        {
            var lecturerId = await sender.Send(createLecturerCommand);
            return Ok($"LecturerId : {lecturerId}");
        }

        [HttpPost("grades")]
        [Authorize(Roles = "ADMIN")]
        public async Task<IActionResult> GradeStudent([FromBody] GradeStudentCommand gradeStudentCommand)
        {
            var gradeId = await sender.Send(gradeStudentCommand);
            return Ok(gradeId);
        }
    }
}
