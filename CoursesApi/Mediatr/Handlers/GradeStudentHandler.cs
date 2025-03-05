using CoursesApi.Data.Repositories;
using CoursesApi.Data.UnitOfWork;
using CoursesApi.Mediatr.Commands;
using MediatR;

namespace CoursesApi.Mediatr.Handlers
{
    public class GradeStudentHandler : IRequestHandler<GradeStudentCommand, Guid>
    {
        private readonly ICourseRepository courseRepository;
        private readonly IUnitOfWork unitOfWork;

        public GradeStudentHandler(ICourseRepository courseRepository, IUnitOfWork unitOfWork)
        {
            this.courseRepository = courseRepository;
            this.unitOfWork = unitOfWork;
        }
        public async Task<Guid> Handle(GradeStudentCommand request, CancellationToken cancellationToken)
        {
            var sheet = await courseRepository.GetStudentCourseByIdAsync(request.studentId ,request.courseId);
            if(sheet == null)
            {
                throw new Exception("record not found.");
            }
            sheet.Grade = request.grade;
            sheet.Finished = true;
            if(sheet.Grade != Models.Enums.Grades.F)
            {
                sheet.Passed = true;
            }
            await unitOfWork.CompleteAsync();

            return sheet.RegisterationId;
        }
    }
}
