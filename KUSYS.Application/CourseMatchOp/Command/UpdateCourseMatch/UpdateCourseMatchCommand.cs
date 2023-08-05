using MediatR;

namespace KUSYS.Application.CourseMatchOp.Command.UpdateCourseMatch
{
    public class UpdateCourseMatchCommand : IRequest<bool>
    {
        public CreateUpdateCourseMatchModel CreateUpdateCourseMatchModel { get; set; }
    }
}
