using AutoMapper;
using KUSYS.Application.CourseMatchOp;
using KUSYS.Application.CourseOp;
using KUSYS.Application.StudentsOp;
using KUSYS.Domain.Entity;

namespace KUSYS.Application.Mappings
{
    public class MapperSettings : Profile
    {
        public MapperSettings()
        {
            CreateMap<Student, StudentsResponse>().ReverseMap();
            CreateMap<Student, CreateUpdateStudentModel>().ReverseMap();

            CreateMap<Course, CreateUpdateCourseModel>().ReverseMap();
            CreateMap<Course, CourseResponse>().ReverseMap();

            CreateMap<CourseMatch, CreateUpdateCourseMatchModel>().ReverseMap();
            CreateMap<CourseMatch, CourseMatchResponse>().ReverseMap();

        }
    }
}
