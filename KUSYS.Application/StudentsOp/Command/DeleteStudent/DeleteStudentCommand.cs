using MediatR;

namespace KUSYS.Application.StudentsOp.Command.DeleteStudent
{
    public class DeleteStudentCommand : IRequest<bool>
    {
        public int id { get; set; }
        public DeleteStudentCommand(int id) { this.id = id; }

    }
}
