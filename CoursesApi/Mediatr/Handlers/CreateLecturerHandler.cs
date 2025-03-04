using CoursesApi.Data.Repositories;
using CoursesApi.Data.UnitOfWork;
using CoursesApi.Mediatr.Commands;
using CoursesApi.Models.Data;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class CreateLecturerHandler : IRequestHandler<CreateLecturerCommand, Guid>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public CreateLecturerHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(CreateLecturerCommand request, CancellationToken cancellationToken)
        {
            var lecturer = new Lecturer
            {
                Id = Guid.NewGuid(),
                Name = request.name,
                Email = request.email,
            };

            await courseRepository.AddLecturerAsync(lecturer);
            await unitOfWork.CompleteAsync();
            return lecturer.Id;
        }
    }
}
