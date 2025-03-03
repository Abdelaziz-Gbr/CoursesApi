using CoursesApi.Models.Dtos;
using CoursesApi.Models.Enums;
using CoursesApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthServices authServices;

        public AuthController(IAuthServices authServices)
        {
            this.authServices = authServices;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] UserRegisterDto userRegisterDto)
        {
            try
            {
                var user = await authServices.SaveUser(userRegisterDto);
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
            return Ok("user created succesfully please login.");
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn([FromForm] UserLogInDto userLogInDto)
        {
            try
            {
                var token = await authServices.GetUserToken(userLogInDto);
                return Ok(token);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
