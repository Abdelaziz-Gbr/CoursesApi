using Asp.Versioning;
using AutoMapper;
using CoursesApi.Data.Repositories;
using CoursesApi.Mediatr.Commands;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;
using MediatR;
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
        private readonly ISender sender;

        public ServicesController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpGet("courses")]
        [Authorize(Roles = "STUDENT")]
        public IActionResult GetAllAvailableCourses()
        {
            return Ok("cs-it-ai-is-ds");
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
    }
}
