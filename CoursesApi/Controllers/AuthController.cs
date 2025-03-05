using CoursesApi.Mediatr.Commands;
using CoursesApi.Mediatr.Queries;
using CoursesApi.Models.Dtos;
using CoursesApi.Models.Enums;
using CoursesApi.Services;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CoursesApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ISender sender;

        public AuthController(ISender sender)
        {
            this.sender = sender;
        }
        [HttpPost]
        [Route("register")]
        public async Task<IActionResult> Register([FromForm] CreateUserCommand createUserCommand)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var userCreated = await sender.Send(createUserCommand);
                if(userCreated)
                {
                    return Ok("user created succesfully please login.");
                }
                else
                {
                    return BadRequest("Invalid input");
                }
            }
            catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [Route("login")]
        public async Task<IActionResult> SignIn([FromForm] SignUserInQuery userCreds)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            try
            {
                var token = await sender.Send(userCreds);
                if(token == null)
                {
                    return ValidationProblem("invalid credentials");
                }
                return Ok(token);
            }
            catch (Exception ex)
            {
                return ValidationProblem(ex.Message);
            }
        }
    }
}
