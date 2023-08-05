using MediatR;

namespace KUSYS.Application.StudentsOp.Command.UpdateStudent
{
    public class UpdateStudentCommand : IRequest<bool>
    {
        public CreateUpdateStudentModel createUpdateStudentModel { get; set; }
    }
}
