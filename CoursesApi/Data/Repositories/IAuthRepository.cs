using CoursesApi.Models.Data;

namespace CoursesApi.Data.Repositories
{
    public interface IAuthRepository
    {
        Task<User> SaveAsync(User user);
        Task<User?> GetUserByEmail(string email);
    }
}
