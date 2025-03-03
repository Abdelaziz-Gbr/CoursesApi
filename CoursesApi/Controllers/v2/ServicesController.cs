using Asp.Versioning;
using CoursesApi.Models.Dtos;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers.v2
{
    [Route("api/v{version:apiVersion}/[controller]")]
    [ApiController]
    [ApiVersion("2.0")]
    public class ServicesController : ControllerBase
    {
        [HttpGet("courses")]
        public IActionResult GetAllAvailableCourses()
        {
            return BadRequest("not yet handled");
        }

        [HttpPost("courses")]
        public async Task<IActionResult> AddCourse(AddCourseDto? addCourseDto)
        {
            return BadRequest("to be made.");
        }
    }
}
