using CoursesApi.Mediatr.Queries;
using CoursesApi.Services;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class SignInUserHandler : IRequestHandler<SignUserInQuery, string>
    {
        private readonly IAuthServices auth;

        public SignInUserHandler(IAuthServices auth)
        {
            this.auth = auth;
        }
        public async Task<string> Handle(SignUserInQuery request, CancellationToken cancellationToken)
        {
            return await auth.GetUserToken(request.Email, request.Password);
        }
    }
}
