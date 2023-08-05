using MediatR;

namespace KUSYS.Application.StudentsOp.Command.CreateStudent
{
    public class CreateStudentCommand : IRequest<bool>
    {
        public CreateUpdateStudentModel createUpdateStudentModel { get; set; }
    }
}
