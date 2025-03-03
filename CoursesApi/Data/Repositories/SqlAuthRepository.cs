using CoursesApi.Data.DbContexts;
using CoursesApi.Models.Data;
using Microsoft.EntityFrameworkCore;

namespace CoursesApi.Data.Repositories
{
    public class SqlAuthRepository : IAuthRepository
    {
        private readonly AuthDbContext dbContext;

        public SqlAuthRepository(AuthDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        public async Task<User?> GetUserByEmail(string email)
        {
            return await dbContext.Users.FirstOrDefaultAsync(x => x.Email == email);
        }

        public async Task<User> SaveAsync(User user)
        {
            var dublicateEmal = await dbContext.Users.FirstOrDefaultAsync(x => x.Email == user.Email);
            if (dublicateEmal != null)
            {
                throw new Exception("Error: Email is already used by another account");
            }
            dbContext.Users.Add(user);
            await dbContext.SaveChangesAsync();
            return user;
        }
    }
}
