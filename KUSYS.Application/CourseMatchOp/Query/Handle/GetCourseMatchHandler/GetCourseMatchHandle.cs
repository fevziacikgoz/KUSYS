using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseMatchOp.Query.GetCourseMatchQueries;
using MediatR;
namespace KUSYS.Application.CourseMatchOp.Query.Handle.GetCourseMatchHandler
{
    public class GetCourseMatchHandle : IRequestHandler<GetCourseMatchQuery, List<CourseMatchResponse>>
    {
        private readonly ICourseMatchRepository _courseMatchRepository;
        private readonly IMapper _mapper;
        public GetCourseMatchHandle(ICourseMatchRepository courseMatchRepository, IMapper mapper)
        {
            _courseMatchRepository = courseMatchRepository;
            _mapper = mapper;
        }

        public async Task<List<CourseMatchResponse>> Handle(GetCourseMatchQuery request, CancellationToken cancellationToken)
        {
            return _mapper.Map<List<CourseMatchResponse>>(_courseMatchRepository.GetAll().ToList());
        }
    }
}
