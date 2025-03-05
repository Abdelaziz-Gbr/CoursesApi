using CoursesApi.Data.Repositories;
using CoursesApi.Data.UnitOfWork;
using CoursesApi.Mediatr.Commands;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class RegisterStudentCourseHandler : IRequestHandler<CreateCourseRegisterationCommand, Guid>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public RegisterStudentCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCourseRegisterationCommand request, CancellationToken cancellationToken)
        {
            var registerationId = await courseRepository.RegisterCourseAsync(request.CourseId, request.StudentId);
            await unitOfWork.CompleteAsync();
            return registerationId;
        }
    }
}
