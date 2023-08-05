using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseOp.Query.GetCourseByIdQueries;
using MediatR;
namespace KUSYS.Application.CourseOp.Query.Handle.GetCourseByIdHandler
{
    public class GetCourseByIdHandle : IRequestHandler<GetCourseByIdQuery, CourseResponse>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public GetCourseByIdHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<CourseResponse> Handle(GetCourseByIdQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<CourseResponse>(_courseRepository.GetByIdAsync(request.id));
        }
    }
}
