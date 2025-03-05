using AutoMapper;
using CoursesApi.Models.Data;
using CoursesApi.Models.Dtos;

namespace CoursesApi.Mappings
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles() 
        {
            CreateMap<AddCourseDto, Course>();
            CreateMap<AddLecturerDto, Lecturer>();
            CreateMap<Lecturer, LecturerDto>().ReverseMap();
            CreateMap<Course, CourseDto>().ReverseMap();
            CreateMap<StudentCourses, RegisteredCourseDto>().ForMember(registeredCourseDto => registeredCourseDto.CourseInfo,
                opt => opt.MapFrom(studentCourse => studentCourse.course)).ReverseMap();
        }
    }
}
