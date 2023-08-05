using MediatR;

namespace KUSYS.Application.CourseMatchOp.Query.GetCourseMatchByStudentIdQueries
{
    public class GetCourseMatchByStudentIdQuery : IRequest<List<CourseMatchStudentResponse>>
    {
        public int studentId { get; set; }
        public GetCourseMatchByStudentIdQuery(int studentId) { this.studentId = studentId; }
    }
}
