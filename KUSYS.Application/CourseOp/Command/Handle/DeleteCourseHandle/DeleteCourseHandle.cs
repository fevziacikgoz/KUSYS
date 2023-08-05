using KUSYS.Application.Common.Interfaces.Repositories;
using KUSYS.Application.CourseOp.Command.DeleteCourse;
using MediatR;

namespace KUSYS.Application.CourseOp.Command.Handle.UpdateCourseHandle
{
    public class DeleteCourseHandle : IRequestHandler<DeleteCourseCommand, bool>
    {
        private readonly ICourseRepository _courseRepository;
        public DeleteCourseHandle(ICourseRepository courseRepository)
        {
            _courseRepository = courseRepository;
        }

        public async Task<bool> Handle(DeleteCourseCommand request, CancellationToken cancellationToken)
        {
            return await _courseRepository.DeleteAsync(request.id);
        }
    }
}
