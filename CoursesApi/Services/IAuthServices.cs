using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;

namespace CoursesApi.Services
{
    public interface IAuthServices
    {
        public Task<User> SaveUser(UserRegisterDto userRegisterDto);

        public Task<string> GetUserToken(UserLogInDto userInfo);
    }
}
