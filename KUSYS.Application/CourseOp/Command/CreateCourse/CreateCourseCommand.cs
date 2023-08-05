using KUSYS.Application.CourseOp;
using MediatR;

namespace KUSYS.Application.CourseOp.Command.CreateCourse
{
    public class CreateCourseCommand : IRequest<bool>
    {
        public CreateUpdateCourseModel CreateUpdateCourseModel { get; set; }
    }
}
