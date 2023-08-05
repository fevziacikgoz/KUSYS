using MediatR;

namespace KUSYS.Application.CourseMatchOp.Command.DeleteCourseMatch
{
    public class DeleteCourseMatchCommand : IRequest<bool>
    {
        public int id { get; set; }
        public DeleteCourseMatchCommand(int id) { this.id = id; }

    }
}
