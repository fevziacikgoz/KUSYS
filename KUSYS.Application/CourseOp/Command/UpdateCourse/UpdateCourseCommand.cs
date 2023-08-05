using KUSYS.Application.CourseOp;
using KUSYS.Application.CourseOp;
using MediatR;

namespace KUSYS.Application.CourseOp.Command.UpdateCourse
{
    public class UpdateCourseCommand : IRequest<bool>
    {
        public CreateUpdateCourseModel CreateUpdateCourseModel  { get; set; }
    }
}
