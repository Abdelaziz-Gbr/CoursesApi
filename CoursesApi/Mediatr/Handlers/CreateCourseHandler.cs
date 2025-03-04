using CoursesApi.Data.Repositories;
using CoursesApi.Data.UnitOfWork;
using CoursesApi.Mediatr.Commands;
using CoursesApi.Models.Data;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class CreateCourseHandler : IRequestHandler<CreateCourseCommand, Guid>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateCourseHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var course = new Course
            {
                Id = Guid.NewGuid(),
                CourseName = request.CourseName,
                Available = true,
                LecturerId = request.LecturerId
            };
            await courseRepository.AddCourseAsync(course);
            await unitOfWork.CompleteAsync();
            return course.Id;
        }
    }
}
