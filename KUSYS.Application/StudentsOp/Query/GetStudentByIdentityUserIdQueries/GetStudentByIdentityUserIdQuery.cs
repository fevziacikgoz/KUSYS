using MediatR;

namespace KUSYS.Application.StudentsOp.Query.GetStudentByIdentityUserIdQueries
{
    public class GetStudentByIdentityUserIdQuery : IRequest<StudentsResponse>
    {
        public string identityUserId { get; set; }
        public GetStudentByIdentityUserIdQuery(string identityUserId) { this.identityUserId = identityUserId; }
    }
}
