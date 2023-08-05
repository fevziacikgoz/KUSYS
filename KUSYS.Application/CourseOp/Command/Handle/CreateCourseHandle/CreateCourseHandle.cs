using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseOp.Command.CreateCourse;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.CourseOp.Command.Handle.CreateCourseHandle
{
    public class CreateCourseHandle : IRequestHandler<CreateCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public CreateCourseHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public async Task<bool> Handle(CreateCourseCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Course>(request.CreateUpdateCourseModel);
            return await _courseRepository.AddAsync(model);
        }
    }
}
