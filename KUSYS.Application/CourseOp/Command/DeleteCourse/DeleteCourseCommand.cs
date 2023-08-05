using MediatR;

namespace KUSYS.Application.CourseOp.Command.DeleteCourse
{
    public class DeleteCourseCommand : IRequest<bool>
    {
        public int id { get; set; }
        public DeleteCourseCommand(int id) { this.id = id; }

    }
}
