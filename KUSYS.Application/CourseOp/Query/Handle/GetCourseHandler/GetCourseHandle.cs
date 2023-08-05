using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseOp.Query.GetCourseQueries;
using MediatR;
namespace KUSYS.Application.CourseOp.Query.Handle.GetCourseHandler
{
    public class GetCourseHandle : IRequestHandler<GetCourseQuery, List<CourseResponse>>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetCourseHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseResponse>> Handle(GetCourseQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CourseResponse>>(_courseRepository.GetAll().ToList());
        }
    }
}
