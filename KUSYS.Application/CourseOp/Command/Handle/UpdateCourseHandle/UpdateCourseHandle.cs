using AutoMapper;
using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseOp.Command.UpdateCourse;
using KUSYS.Domain.Entity;
using MediatR;

namespace KUSYS.Application.CourseOp.Command.Handle.UpdateCourseHandle
{
    public class UpdateCourseHandle : IRequestHandler<UpdateCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        private readonly IMapper _mapper;
        public UpdateCourseHandle(ICourseRepository courseRepository, IMapper mapper)
        {
            _courseRepository = courseRepository;
            _mapper = mapper;
        }

        public Task<bool> Handle(UpdateCourseCommand request, CancellationToken cancellationToken)
        {
            var model = _mapper.Map<Course>(request.CreateUpdateCourseModel);
            return Task.FromResult(_courseRepository.Update(model));
        }
    }
}
