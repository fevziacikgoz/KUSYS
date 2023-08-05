using MediatR;

namespace KUSYS.Application.StudentsOp.Query.GetStudentByIdQueries
{
    public class GetStudentByIdQuery : IRequest<StudentsResponse>
    {
        public int id { get; set; }
        public GetStudentByIdQuery(int id) { this.id = id; }
    }
}
