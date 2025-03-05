using CoursesApi.Mediatr.Commands;
using CoursesApi.Services;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class CreateUserHandler : IRequestHandler<CreateUserCommand, bool>
    {
        private readonly IAuthServices authServices;

        public CreateUserHandler(IAuthServices authServices)
        {
            this.authServices = authServices;
        }
        public async Task<bool> Handle(CreateUserCommand request, CancellationToken cancellationToken)
        {
            var user = await authServices.SaveUser(request);

            return user != null;
        }
    }
}

