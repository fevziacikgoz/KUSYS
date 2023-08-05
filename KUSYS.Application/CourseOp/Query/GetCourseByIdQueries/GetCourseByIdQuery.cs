using MediatR;

namespace KUSYS.Application.CourseOp.Query.GetCourseByIdQueries
{
    public class GetCourseByIdQuery : IRequest<CourseResponse>
    {
        public int id { get; set; }
        public GetCourseByIdQuery(int id) { this.id = id; }
    }
}
