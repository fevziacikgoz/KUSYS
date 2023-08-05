using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseMatchOp.Query.GetCourseMatchByStudentIdQueries;
using MediatR;
namespace KUSYS.Application.CourseMatchOp.Query.Handle.GetCourseMatchByIdHandler
{
    public class GetCourseMatchByStudentIdHandle : IRequestHandler<GetCourseMatchByStudentIdQuery, List<CourseMatchStudentResponse>>
    {
        private readonly ICourseMatchRepository _courseMatchRepository;
        private readonly IMapper _mapper;
        public GetCourseMatchByStudentIdHandle(ICourseMatchRepository courseMatchRepository, IMapper mapper)
        {
            _courseMatchRepository = courseMatchRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseMatchStudentResponse>> Handle(GetCourseMatchByStudentIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CourseMatchStudentResponse>>(_courseMatchRepository.GetWhere(f => f.StudentId == request.studentId, x => x.Student, x => x.Course).Select(x => new CourseMatchStudentResponse
            {
                Id = x.Id,
                CourseId = x.CourseId,
                StudentId = x.StudentId,
                CourseName = x.Course.Name,
                CreatedDate = x.CreatedDate,
                UpdatedDate = x.UpdatedDate,
                IsActive = x.IsActive
            }).ToList());
        }
    }
}
