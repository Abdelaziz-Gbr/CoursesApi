using CoursesApi.Mediatr.Commands;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;

namespace CoursesApi.Services
{
    public interface IAuthServices
    {
        public Task<User> SaveUser(CreateUserCommand userRegisterDto);

        public Task<string> GetUserToken(string Email, string Password);
    }
}
